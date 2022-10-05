using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{ 
    public Button resetButton;
    public BallSpawner ballSpawner;
    private drawLine lineDrawer;
    
    void Start(){
        resetButton.onClick.AddListener(ResetOnClick);
        lineDrawer = GetComponent<drawLine>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            lineDrawer.startLine();
        }else if(Input.GetMouseButton(0)){
            lineDrawer.finishLine();
        }else if(Input.GetMouseButtonDown(1)){
            lineDrawer.destroyIfAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }else if(Input.GetKeyDown("space")){
            BallSpawner b = Instantiate(ballSpawner, Camera.main.ScreenToWorldPoint(Input.mousePosition), ballSpawner.transform.localRotation);
            b.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, 0);
        }
    }
    void ResetOnClick(){
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls) {
                Destroy(ball);
            }
            GameObject[] allBallSpawners = GameObject.FindGameObjectsWithTag("BallSpawner");
            foreach (GameObject bs in allBallSpawners){
                Destroy(bs);
            }
            lineDrawer.DestroyAll();    
	}

}
