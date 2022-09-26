using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody2D rb;
     public AudioSource sound;
     public AudioClip[] allKeys;

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
            setPitchAsVelocity();
            playSound();
        }
    }

    private void playSound(){
        sound.Play();
    }

    private void setPitchAsVelocity(){
        float velocity=Vector2.SqrMagnitude(this.rb.velocity);
        int velocityArrValue = (int) (velocity / 50 * allKeys.Length);
        if(velocityArrValue <= 23 && velocityArrValue >=0){
            this.sound.clip = allKeys[velocityArrValue];
        }
    }
}
