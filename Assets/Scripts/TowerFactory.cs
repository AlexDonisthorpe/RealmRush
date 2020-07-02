using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int maxTowers = 3;
    private int currentTowers = 0;
    
    public void AddTower(Waypoint baseWaypoint)
    {
        if (currentTowers == maxTowers)
        {
            Debug.Log("Can't place any more towers, the maximum number of towers has already been allocated");
        }
        else
        {
            Transform parent = GameObject.Find("Towers").transform;
            Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity, parent);
            baseWaypoint.isPlaceable = false;
            currentTowers++;
        }
    }



}
