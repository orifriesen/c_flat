using UnityEngine;
using UnityEngine.UI;
public class BallSpawner : MonoBehaviour
{
    private float lastSpawn = 0.0f;
    public float delay;
    public GameObject ball;

    public GameObject trashButtonExample;
    public GameObject speedSliderExample;

    private Button trashButton;
    private Slider speedSlider;

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
        Vector3 pos = this.transform.position; 
        float maxY = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y; 
        float yOffset = (this.transform.position.y + 0.5f > maxY) ? -.50f : .50f;


        GameObject speedSlider = Instantiate(speedSliderExample, Camera.main.ScreenToWorldPoint(this.transform.position), this.transform.localRotation);
        speedSlider.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        speedSlider.transform.position = new Vector2(pos.x -.5f, pos.y+yOffset);
        speedSlider.GetComponent<SpeedSlider>().SetBallSpawner(this);
        speedSlider.GetComponent<SpeedSlider>().setValFromDelay(delay);

        GameObject trashButton = Instantiate(trashButtonExample, Camera.main.ScreenToWorldPoint(this.transform.position), this.transform.localRotation);
        trashButton.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        trashButton.transform.position = new Vector2(pos.x +0.50f, pos.y+yOffset);
        trashButton.GetComponent<TrashButton>().SetBallSpawner(this.gameObject);
        trashButton.GetComponent<TrashButton>().setSlider(speedSlider);
    }


}
