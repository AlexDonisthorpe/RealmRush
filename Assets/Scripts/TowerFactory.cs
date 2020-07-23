using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 3;

    Queue<Tower> towerQueue = new Queue<Tower>();
    
    public void AddTower(Waypoint baseWaypoint)
    {
        var towers = towerQueue.Count;
        if(towers < maxTowers)
        {
            InstantiateNewTower(baseWaypoint);
        } else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        Debug.Log("Can't place any more towers, the maximum number of towers has already been allocated");
        Tower oldTower = towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        oldTower.baseWaypoint = baseWaypoint;
        oldTower.transform.position = baseWaypoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Transform parent = GameObject.Find("Towers").transform;
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, parent);
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
        newTower.baseWaypoint = baseWaypoint;
    }
}
