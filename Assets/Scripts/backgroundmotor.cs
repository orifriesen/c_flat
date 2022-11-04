using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmotor : MonoBehaviour
{
    
    private float moveSpeed = 0.0015f;
    public float XPosVelocity = -1;
    public float YPosVelocity = -1;
    private float moveSpeedToReach = 0.0015f;
    private float delaySpeedChange = 5f;
    private float lastSpeedChange = 0f;


    private BoxCollider2D collider2D;
    void Start(){
        collider2D = GetComponent<BoxCollider2D>();
        
        this.transform.Translate(new Vector3(Random.Range(-4, 0), Random.Range(-6, 0), 0));
        
        if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
        }
        if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
        }
    }


    void Update()
    {   
        if((Time.time > delaySpeedChange + lastSpeedChange)){
            moveSpeedToReach = Random.Range(0.001f, 0.002f);
            lastSpeedChange = Time.time;
        }
        
        if(moveSpeed!=moveSpeedToReach){
            moveSpeed += (moveSpeedToReach-moveSpeed)/600f;
        }
        transform.Translate(new Vector3(moveSpeed * XPosVelocity, moveSpeed * YPosVelocity, 0));

        if(!collider2D.bounds.Contains(new Vector3(9.5f, 0, 0)) && XPosVelocity == -1){
            XPosVelocity *= -1;
            if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
            }
        }
        if(!collider2D.bounds.Contains(new Vector3(-9.5f, 0, 0)) && XPosVelocity == 1){
            XPosVelocity *= -1;
            if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
            }
        }
        if(!collider2D.bounds.Contains(new Vector3(0, 5.5f, 0)) && YPosVelocity == -1){
            YPosVelocity *= -1;
            if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
            }
        }
        if(!collider2D.bounds.Contains(new Vector3(0, -5.5f, 0)) && YPosVelocity == 1){
            YPosVelocity *= -1;
            if(Random.Range(0, 2) > 1){
                YPosVelocity *= -1;
            }
        }
    }
}
