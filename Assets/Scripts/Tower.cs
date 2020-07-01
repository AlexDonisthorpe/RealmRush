using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 100f;
    [SerializeField] ParticleSystem projectileParticle;

    bool enemyExists = false;
    // Update is called once per frame
    void Update()
    {
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

    private void ShootLasers()
    {
        ParticleSystem lasers = GetComponentInChildren<ParticleSystem>();
        lasers.Play();
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, transform.position);
        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
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
