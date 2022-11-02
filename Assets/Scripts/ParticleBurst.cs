using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    private ParticleSystem.MainModule ps;

    private void Start() {
        ps = GetComponent<ParticleSystem>().main;
    }

    //Triggers the particle effect if it collides with a line
    void OnTriggerExit2D(Collider2D other) {
        if(!other.gameObject.CompareTag("line")){
            return;
        }
        ps.startColor = other.gameObject.GetComponent<lineScript>().color;
        var em = collisionParticleSystem.emission;
        em.enabled = true;
        collisionParticleSystem.Play();
    }
}
