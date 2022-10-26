using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public AudioSource sound;
    public AudioClip[] allKeys;
    public AudioClip[] minorKey;
    public AudioClip[] majorKey;
    public AudioClip[] harmonic;

    private ParticleSystem.MainModule ps;
    private float lastSound = 0.0f;
    private float delay = 0.05f;
    private float minVelocity = 0.05f;
    private double minX;
    private double maxX;
    private double minY;
    private double maxY;

    void Start()
    {   
        ps = GetComponent<ParticleSystem>().main;
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        lastSound = Time.time;

        Vector2 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        maxX = cameraBounds.x;
        maxY = cameraBounds.y;
        minY = -cameraBounds.y;
        minX = -cameraBounds.x;

    }

    //Destroys this object if it is offscreen and it isn't playing sound
    //Also destroys each audio source which isn't playing
    void Update()
    {        
        double xPos = this.transform.position.x;
        double yPos = this.transform.position.y;

        bool playing = false;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach(AudioSource audioSource in audioSources){
            if(audioSource.isPlaying){
                playing = true;
            }else{
                Destroy(audioSource);
            }
        }

        if(!playing && (minY > yPos || maxY < yPos || minX > xPos || maxX < xPos)){
                Destroy(gameObject);
        }

    }
    //gameObject.layer != 6 && 
    //checks if the other colliding object is a line, if so plays a sound assuming a few conditions are met, i.e. velocity, delay
    private void OnCollisionEnter2D(Collision2D other) {

        ps.startColor = other.gameObject.GetComponent<lineScript>().color;

        if((Time.time > delay + lastSound) && (Vector2.SqrMagnitude(this.rb.velocity) > minVelocity)){
            playClipOnVelocity(harmonic, other.gameObject.GetComponent<lineScript>().colorInt);
            lastSound = Time.time;
        }
    }

    //Plays a clip from a new audiosource, the clip is based off velocity, and pitch scales with line color
    //TODO handling of pitch based on color is ugly
    private void playClipOnVelocity(AudioClip[] audioClips, double matPos){
        
        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        double velocityNormalized = Mathf.Log(velocity, 165)*(1.0/7.0) + (velocity/165)*(6.0/7.0);
        int velocityArrValue = (int) (velocityNormalized * audioClips.Length);

        velocityArrValue = (int)(velocityArrValue / 3.0 * matPos);

        if(velocityArrValue >= audioClips.Length){
            velocityArrValue = audioClips.Length -1;
        }else if(velocityArrValue < 0){
            velocityArrValue = 0;
        }

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[velocityArrValue];


        // double p = (matPos+3) / 6.0;
        // double v = 1- (.2 + (p-1)/2.0);
        // v = (v>1) ? 1 : v;
        // audioSource.pitch = (float)p;
        // audioSource.volume = (float)v;
        
        audioSource.Play();
    }
}
