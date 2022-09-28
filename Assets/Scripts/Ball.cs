using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody2D rb;
     public AudioSource sound;
     public AudioClip[] allKeys;
     public AudioClip[] minorKey;
     public AudioClip[] majorKey;
     public AudioClip[] harmonic;

     private float lastSound = 0.0f;
     private float delay = 0.05f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        lastSound = Time.time;
    }

    void Update()
    {
        if(!GetComponent<Renderer>().isVisible){
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer != 6){
            return;
        }

        if(Time.time > delay + lastSound && Vector2.SqrMagnitude(this.rb.velocity) > .05f){
            playClipOnVelocity(harmonic);
            lastSound = Time.time;
        }
    }

    private void playClipOnVelocity(AudioClip[] audioClips){
        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        int velocityArrValue = (int) (velocity / 110 * audioClips.Length);
        if(velocityArrValue >= audioClips.Length){
            velocityArrValue = audioClips.Length -1;
        }
        this.sound.PlayOneShot(audioClips[velocityArrValue]);
    }
}
