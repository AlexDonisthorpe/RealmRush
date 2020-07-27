using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 6f;
    [SerializeField] EnemyMovement enemyPrefab;

    Transform enemyParent;
    [SerializeField] PlayerScore scoreBoard;

    void Start()
    {
        enemyParent = GameObject.Find("Enemies").transform;
        StartCoroutine("SpawnEnemies");
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // todo set end condition
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity, enemyParent);
            scoreBoard.UpdateScore();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
