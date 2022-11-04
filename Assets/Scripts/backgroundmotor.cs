using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmotor : MonoBehaviour
{
    
    private float moveSpeedY;
    private float moveSpeedX;
    private float moveSpeedToReachX;
     private float moveSpeedToReachY;
    private float delaySpeedChange = 5f;
    private float lastSpeedChange = 0f;

    private float moveSpeedMin = 0.0002f;
    private float moveSpeedMax = 0.0005f;
    private BoxCollider2D collider2D;

    public Sprite[] texNames;
    void Start(){

        int TexInt = Random.Range(0, texNames.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = texNames[TexInt];

        collider2D = GetComponent<BoxCollider2D>();
        
        this.transform.Translate(new Vector3(Random.Range(-4, 0), Random.Range(-6, 0), 0));
        
        moveSpeedX = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedY = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedToReachX = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedToReachY = (moveSpeedMax + moveSpeedMin) /2f;

        if(Random.Range(0, 2) > 1){
                moveSpeedX *= -1;
        }
        if(Random.Range(0, 2) > 1){
                moveSpeedY *= -1;
        }
    }


    void Update()
    {   
        if((Time.time > delaySpeedChange + lastSpeedChange)){
            moveSpeedToReachX = Random.Range(moveSpeedMin, moveSpeedMax);
            moveSpeedToReachY = Random.Range(moveSpeedMin, moveSpeedMax);
            lastSpeedChange = Time.time;
        }
        
        if(moveSpeedX!=moveSpeedToReachX){
            moveSpeedX += (moveSpeedToReachX-moveSpeedX)/600f;
        }
        if(moveSpeedY!=moveSpeedToReachY){
            moveSpeedY += (moveSpeedToReachY-moveSpeedY)/600f;
        }
        
        transform.Translate(new Vector3(moveSpeedX, moveSpeedY, 0));

        if(!collider2D.bounds.Contains(new Vector3(10f, 0, 0)) && moveSpeedToReachX < 0){
            moveSpeedToReachX *= -1;
        }
        if(!collider2D.bounds.Contains(new Vector3(-10f, 0, 0)) && moveSpeedToReachX > 0){
            moveSpeedToReachX *= -1;
        }
        if(!collider2D.bounds.Contains(new Vector3(0, 6f, 0)) && moveSpeedToReachY < 0){
            moveSpeedToReachY *= -1;
        }
        if(!collider2D.bounds.Contains(new Vector3(0, -6f, 0)) && moveSpeedToReachY > 0){
            moveSpeedToReachY *= -1;
        }
    }
}
