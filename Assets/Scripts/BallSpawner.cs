using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float lastSpawn = 0.0f;
    public float delay;
    public GameObject ball;

    void Update()
    {
        if(Time.time > delay + lastSpawn){

            GameObject b = Instantiate(ball,  this.transform.localPosition, this.transform.localRotation);
            

            GameObject[] otherBalls = GameObject.FindGameObjectsWithTag("Ball");

            foreach (GameObject ball in otherBalls) {
                Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), b.GetComponent<Collider2D>()); 
            }    

            lastSpawn=Time.time;
    }
    }

}
