using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
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

    private Camera thisCamera;

    private Vector2 screenBounds;
    public Sprite[] textures;
    private float alphaToReach;
    private bool goingToDestroyOthers;
    private float timeToDestroyOthers;
    void Start(){
        DontDestroyOnLoad(this);
        alphaToReach = this.GetComponent<SpriteRenderer>().color.a;
        thisCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        IgnoreAllUI();

        screenBounds = thisCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, thisCamera.transform.position.z));
        screenBounds.x *= 1.35f;
        screenBounds.y *= 1.35f;

        xMult=1;
        yMult=1;

        int TexInt = Random.Range(0, textures.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = textures[TexInt];

        thisCollider2D = GetComponent<BoxCollider2D>();
        
        this.transform.Translate(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));
        
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
        if(goingToDestroyOthers){
            IgnoreAllUI();
            if(Time.time > timeToDestroyOthers){
                destroyOthers();
                goingToDestroyOthers = false;
            }
        }
        if(Time.timeScale == 0){
            return;
        }

        float a = this.GetComponent<SpriteRenderer>().color.a;
        if(a != alphaToReach){
            float newA = a;
            a += (alphaToReach-a)/600f;
            this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,a);
        }

        if(a+.01f >alphaToReach && a-.01f < alphaToReach){
            alphaToReach = a;
        }

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
    public void changeAlphaToReach(float a){
        alphaToReach = a;
        thisCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    public void onMove(){
        goingToDestroyOthers = true;
        timeToDestroyOthers = Time.time + 0.05f;
    }
    public void destroyOthers(){
        GameObject[] backgrounds = GameObject.FindGameObjectsWithTag("Background");
        foreach(GameObject go in backgrounds){
            if(!go.Equals(this.gameObject)){
                Destroy(go);
            }
        }
    }

    private void IgnoreAllUI(){
        GameObject[] PhysicsUI = GameObject.FindGameObjectsWithTag("PhysicsUI");
        foreach(GameObject go in PhysicsUI){
                Physics2D.IgnoreCollision(go.GetComponent<Collider2D>(), this.GetComponent<Collider2D>()); 
        }
    }

}
