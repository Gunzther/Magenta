using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            
    public int currentHealth;                  
    public ParticleSystem hitParticles;   
    public ParticleSystem dieParticles;
    //public AudioClip deathClip;                 

    //AudioSource enemyAudio;                     
    CapsuleCollider capsuleCollider;
    Animator anim;
    bool isDead;                                                            

    void Awake()
    {
        // Setting up the references.
        //enemyAudio = GetComponent<AudioSource>();
        hitParticles = transform.GetComponentInChildren<ParticleSystem>();
        capsuleCollider = transform.GetComponent<CapsuleCollider>();
        anim = transform.GetComponent<Animator>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead) return;

        //enemyAudio.Play();
        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        anim.SetTrigger("Die");
        dieParticles.Play();

        // After 0.5 seconds destory the enemy.
        Destroy(gameObject, 1f);

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play();
    }
}
