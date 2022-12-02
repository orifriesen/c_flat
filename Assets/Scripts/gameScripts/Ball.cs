using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    private ParticleSystem.MainModule ps;
    private Rigidbody2D rb;
    public AudioSource sound;
    public AudioClip[] allKeys;
    public AudioClip[] minorKey;
    public AudioClip[] majorKey;
    public AudioClip[] harmonic;

    public AudioClip[] baseSounds;

    public AudioClip[] drumSounds;

    public AudioClip[] guitarSounds;

    public AudioMixerGroup mixer;
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
        if(!other.gameObject.CompareTag("line")){
            return;
        }

        if((Time.time > delay + lastSound) && (Vector2.SqrMagnitude(this.rb.velocity) > minVelocity)){
            playClipOnVelocity(other.gameObject.GetComponent<lineScript>().colorInt, other.gameObject.GetComponent<lineScript>().instrumentInt);
            lastSound = Time.time;
            ps.startColor = other.gameObject.GetComponent<lineScript>().color;
            var em = collisionParticleSystem.emission;
            em.enabled = true;
            collisionParticleSystem.Play();
        }
    }

    //Plays a clip from a new audiosource, the clip is based off velocity, and pitch scales with line color
    //TODO handling of pitch based on color is ugly
    private void playClipOnVelocity(double matPos, int instrumentInt){
        if(instrumentInt == -1){
            return;
        }
        AudioClip[] audioClips = null;

        if(instrumentInt <= 2){ audioClips = harmonic; }
        else if(instrumentInt <= 5) { audioClips = guitarSounds;}
        else if(instrumentInt <= 8) { audioClips = baseSounds;} 
        else if(instrumentInt <= 12) {
            audioClips = drumSounds;
            AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
            audioSource2.clip = audioClips[instrumentInt-9];
            audioSource2.Play();
            return;
        } 

        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        double velocityNormalized = Mathf.Log(velocity, 165)*(1.0/7.0) + (velocity/165)*(6.0/7.0);
        int velocityArrValue = (int) (velocityNormalized * audioClips.Length);

        velocityArrValue = (int)(velocityArrValue / 3.0 * matPos);

        if(velocityArrValue >= audioClips.Length){
            velocityArrValue = audioClips.Length -1;
        }
        if(velocityArrValue < 0){
            velocityArrValue = 0;
        }

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClips[velocityArrValue];

        // AudioMixerGroup mixer = Resources.Load("ChangeSound") as AudioMixerGroup;
        // audioSource.outputAudioMixerGroup = mixer;
        
        audioSource.Play();
        //audioSource.outputAudioMixerGroup = mixer;
    }
}