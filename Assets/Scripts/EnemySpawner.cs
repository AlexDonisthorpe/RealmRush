using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 6f;
    [SerializeField] EnemyMovement enemyPrefab;

    void Start()
    {
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // todo set end condition
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
