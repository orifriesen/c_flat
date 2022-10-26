using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;

    //Triggers the particle effect if it collides with a line
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("line")){
            var em = collisionParticleSystem.emission;

            em.enabled = true;
            collisionParticleSystem.Play();
        }
    }
}
