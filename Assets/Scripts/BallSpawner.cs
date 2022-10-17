using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float lastSpawn = 0.0f;
    public float delay;
    public GameObject ball;


    //spawns a ball every delay seconds
    void Update()
    {
        if(Time.time > delay + lastSpawn){

            GameObject newBall = Instantiate(ball,  this.transform.localPosition, this.transform.localRotation);
            

            GameObject[] otherBalls = GameObject.FindGameObjectsWithTag("Ball");

            foreach (GameObject ball in otherBalls) {
                Physics2D.IgnoreCollision(newBall.GetComponent<Collider2D>(), ball.GetComponent<Collider2D>()); 
            }    

            lastSpawn=Time.time;
    }
    }

}
