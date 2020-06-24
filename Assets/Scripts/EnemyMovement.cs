using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] float delayTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        Debug.Log("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {
            var nextPosition = waypoint.transform.position;
            Debug.Log("Visiting block: " + waypoint);
            transform.position = nextPosition;
            yield return new WaitForSeconds(delayTimer);
        }
        Debug.Log("Ending Patrol");
    }
}
