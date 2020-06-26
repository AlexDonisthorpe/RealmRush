using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float delayTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        Debug.Log("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            var nextPosition = waypoint.transform.position;
            transform.position = nextPosition;
            yield return new WaitForSeconds(delayTimer);
        }
        Debug.Log("Ending Patrol");
    }
}
