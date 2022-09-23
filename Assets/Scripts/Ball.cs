using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody2D rb;
     public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<Renderer>().isVisible){
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 6){
            this.sound.pitch = getVelocityAsPitch();
            playSound();
        }
    }

    private void playSound(){
        sound.Play();
    }

    private float getVelocityAsPitch(){
        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        return (Vector2.SqrMagnitude(this.rb.velocity) / 20) - (float)0.5;
    }
}
