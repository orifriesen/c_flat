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

            Physics2D.IgnoreCollision(newBall.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Background").GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(newBall.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("PauseUI").GetComponent<BoxCollider2D>());

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
        float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float minX = -maxX;

        float yOffset = (pos.y + 0.5f > maxY) ? -.50f : .50f;
        float xOffset = 0;
        if(pos.x +.45f > maxX){
            xOffset = (maxX-pos.x) -.75f;
        }else if(pos.x -1f < minX){
            xOffset = (minX-pos.x) +1.3f;
        }

        GameObject speedSlider = Instantiate(speedSliderExample, Camera.main.ScreenToWorldPoint(this.transform.position), this.transform.localRotation);
        speedSlider.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        speedSlider.transform.position = new Vector2(pos.x -.5f+xOffset, pos.y+yOffset);
        speedSlider.GetComponent<SpeedSlider>().SetBallSpawner(this);
        speedSlider.GetComponent<SpeedSlider>().setValFromDelay(delay);

        GameObject trashButton = Instantiate(trashButtonExample, Camera.main.ScreenToWorldPoint(this.transform.position), this.transform.localRotation);
         foreach (Transform child in trashButton.transform) {
            Destroy(child.gameObject);
        }
        trashButton.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
        trashButton.transform.position = new Vector2(pos.x +0.50f+xOffset, pos.y+yOffset);
        trashButton.GetComponent<TrashButton>().SetBallSpawner(this.gameObject);
        trashButton.GetComponent<TrashButton>().setSlider(speedSlider);
    }


}
