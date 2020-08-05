using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 1f;
    [SerializeField] AudioClip baseReachedSFX;
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            var nextPosition = waypoint.transform.position;
            transform.position = nextPosition;
            yield return new WaitForSeconds(movementPeriod);
        }
        AudioSource.PlayClipAtPoint(baseReachedSFX, transform.position);
        GetComponent<EnemyDamage>().KillEnemy();
    }
}
