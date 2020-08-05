using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlesPrefab;
    [SerializeField] ParticleSystem deathFXPrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float deathDelay = 1f;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

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
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject);
    }

    private void PlayDeathVFX()
    {
        ParticleSystem deathFX = Instantiate(deathFXPrefab, transform.position, Quaternion.identity);
        Destroy(deathFX.gameObject, deathDelay);
    }

    void ProcessHit()
    {
        myAudioSource.PlayOneShot(hitSFX);
        hitParticlesPrefab.Play();
        hitPoints--;
    }
}
