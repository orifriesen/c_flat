using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineBurst : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;

    //Triggers the particle effect if the ball hits a line
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Ball")){
            var em = collisionParticleSystem.emission;

            em.enabled = true;
            collisionParticleSystem.Play();
        }
    }
}
