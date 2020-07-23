using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 100f;
    [SerializeField] ParticleSystem projectileParticle;
    public Waypoint baseWaypoint;

    // State
    [SerializeField] Transform targetEnemy;

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            LookAtEnemy();
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach(EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy);
            targetEnemy = closestEnemy;
        }
    }

    private Transform GetClosestEnemy(Transform currentEnemy, EnemyDamage testEnemy)
    {
        float testEnemyDistance = CheckEnemyDistance(testEnemy.transform);
        float closestEnemyDistance = CheckEnemyDistance(currentEnemy.transform);

        if (testEnemyDistance < closestEnemyDistance)
        {
            currentEnemy = testEnemy.transform;
        }

        return currentEnemy;
    }

    private void ShootLasers()
    {
        ParticleSystem lasers = GetComponentInChildren<ParticleSystem>();
        lasers.Play();
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = CheckEnemyDistance(targetEnemy);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private float CheckEnemyDistance(Transform enemy)
    {
        return Vector3.Distance(enemy.transform.position, transform.position);
    }

    private void Shoot(bool active)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = active;
    }

    private void LookAtEnemy()
    {
        objectToPan.LookAt(targetEnemy);
    }
}
