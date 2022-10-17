using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float lastSpawn = 0.0f;
    public float delay;
    public GameObject ball;

    public GameObject trashButtonExample;
    public GameObject speedSliderExample;

    private GameObject trashButton;
    private GameObject speedSlider;

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

    public void CreateButtons(){
        // GameObject trashButton = Instantiate(trashButtonExample, this.transform.localPosition, this.transform.localRotation);
        // trashButton.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        

        // GameObject speedSlider = Instantiate(speedSliderExample, this.transform.localPosition, this.transform.localRotation);
        // speedSlider.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
    }

}
