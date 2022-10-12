using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    // public AudioSource sound;
    public AudioClip[] allKeys;
    public AudioClip[] minorKey;
    public AudioClip[] majorKey;
    public AudioClip[] harmonic;

    private float lastSound = 0.0f;
    private float delay = 0.05f;

    private double minX;
    private double maxX;
    private double minY;
    private double maxY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        lastSound = Time.time;

        Vector2 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxX = cameraBounds.x;
        maxY = cameraBounds.y;
        minY = -cameraBounds.y;
        minX = -cameraBounds.x;

    }

    void Update()
    {
        
        double xPos = this.transform.position.x;
        double yPos = this.transform.position.y;

        bool playing = false;
        foreach(AudioSource audioSource in GetComponents<AudioSource>()){
            if(audioSource.isPlaying){
                playing = true;
                break;
            }else{
                Destroy(audioSource);
            }
        }

        if(minY > yPos || maxY < yPos || minX > xPos || maxX < xPos){
            if(!playing){
                Destroy(gameObject);
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer != 6){
            return;
        }
    
        if(Time.time > delay + lastSound && Vector2.SqrMagnitude(this.rb.velocity) > .05f){
            playClipOnVelocity(harmonic, other.gameObject.GetComponent<lineScript>().colorInt);
            lastSound = Time.time;
        }
    }


    private void playClipOnVelocity(AudioClip[] audioClips, int matPos){
        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        double velocityNormalized = Mathf.Log(velocity, 170)*(1.0/7.0) + (velocity/170)*(6.0/7.0);
        int velocityArrValue = (int) (velocityNormalized * audioClips.Length);

        if(velocityArrValue >= audioClips.Length){
            velocityArrValue = audioClips.Length -1;
        }else if(velocityArrValue < 0){
            velocityArrValue = 0;
        }

        double p = (matPos+2) / 5.0;

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[velocityArrValue];
        audioSource.pitch = (float)p;
        audioSource.Play();
    }
}
