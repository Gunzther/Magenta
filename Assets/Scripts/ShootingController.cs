using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public int damagePerShot = 20;                  
    public float timeBetweenBullets = 0.15f;        
    public float range = 20f;
    public Light gunLight;                                 

    float timer;                                    
    Ray shootRay;                                   
    RaycastHit shootHit;                            
    int shootableMask;                              
    LineRenderer gunLine;                           
    //AudioSource gunAudio;                           
    //ParticleSystem gunParticles;                    
    float effectsDisplayTime = 0.2f;                

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");

        gunLine = GetComponent<LineRenderer>();
        //gunParticles = GetComponent<ParticleSystem>();
        //gunAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        gunLine.SetPosition(0, shootRay.origin);
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        //gunAudio.Play();

        gunLight.enabled = true;

        //gunParticles.Stop();
        //gunParticles.Play();

        gunLine.enabled = true;

        shootRay.origin = gunLine.transform.position;
        shootRay.direction = gunLine.transform.forward;

        gunLine.SetPosition(0, shootRay.origin);

        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                //print(shootHit.transform.name);
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }

        else gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
}
