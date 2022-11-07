using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmotor : MonoBehaviour
{
    
    private float moveSpeedY;
    private float moveSpeedX;

    private float xMult;
    private float yMult;

    private float moveSpeedToReachX;
     private float moveSpeedToReachY;
    private float delaySpeedChange = 5f;
    private float lastSpeedChange = 0f;

    private float moveSpeedMin = 0.0002f;
    private float moveSpeedMax = 0.0005f;
    private BoxCollider2D thisCollider2D;

    public Camera thisCamera;

    private Vector2 screenBounds;
    public Sprite[] textures;
    void Start(){

        screenBounds = thisCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, thisCamera.transform.position.z));
        screenBounds.x *= 1.2f;
        screenBounds.y *= 1.25f;

        xMult=1;
        yMult=1;

        int TexInt = Random.Range(0, textures.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = textures[TexInt];

        thisCollider2D = GetComponent<BoxCollider2D>();
        
        this.transform.Translate(new Vector3(Random.Range(-4, 0), Random.Range(-6, 0), 0));
        
        moveSpeedX = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedY = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedToReachX = (moveSpeedMax + moveSpeedMin) /2f;
        moveSpeedToReachY = (moveSpeedMax + moveSpeedMin) /2f;

        if(Random.Range(0, 2) > 1){
                xMult *= -1;
        }
        if(Random.Range(0, 2) > 1){
                yMult *= -1;
        }
    }


    void Update()
    {   
        if(Time.timeScale == 0){
            return;
        }
        
        Debug.Log(screenBounds.x + " " + screenBounds.y);
        if(!thisCollider2D.bounds.Contains(new Vector3(screenBounds.x, 0, 0)) && xMult < 0){
            xMult *= -1;
        }
        if(!thisCollider2D.bounds.Contains(new Vector3(-screenBounds.x, 0, 0)) && xMult > 0){
            xMult *= -1;
        }
        if(!thisCollider2D.bounds.Contains(new Vector3(0, screenBounds.y, 0)) && yMult < 0){
            yMult *= -1;
        }
        if(!thisCollider2D.bounds.Contains(new Vector3(0, -screenBounds.y, 0)) && yMult > 0){
            yMult *= -1;
        }

        if((Time.time > delaySpeedChange + lastSpeedChange)){
            moveSpeedToReachX = Random.Range(moveSpeedMin, moveSpeedMax) * xMult;
            moveSpeedToReachY = Random.Range(moveSpeedMin, moveSpeedMax) * yMult;
            lastSpeedChange = Time.time;
        }
        
        moveSpeedX += (moveSpeedToReachX-moveSpeedX)/600f;
        moveSpeedY += (moveSpeedToReachY-moveSpeedY)/600f;

        transform.Translate(new Vector3(moveSpeedX, moveSpeedY, 0));

    }
}
