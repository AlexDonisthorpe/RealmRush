using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathFXPrefab;
    [SerializeField] float deathDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        ParticleSystem deathFX = Instantiate(deathFXPrefab, transform.position, Quaternion.identity);
        Destroy(deathFX.gameObject, deathDelay);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitParticlesPrefab.Play();
        hitPoints--;
    }
}
