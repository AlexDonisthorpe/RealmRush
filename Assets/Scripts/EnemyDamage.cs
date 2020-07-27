using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathFXPrefab;
    [SerializeField] float deathDelay = 1f;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        PlayDeathVFX();
        Destroy(gameObject);
    }

    private void PlayDeathVFX()
    {
        ParticleSystem deathFX = Instantiate(deathFXPrefab, transform.position, Quaternion.identity);
        Destroy(deathFX.gameObject, deathDelay);
    }

    void ProcessHit()
    {
        hitParticlesPrefab.Play();
        hitPoints--;
    }
}
