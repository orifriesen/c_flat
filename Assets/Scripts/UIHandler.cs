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
        }else if(Input.GetKeyDown("b")){
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallSpawner b = Instantiate(ballSpawner, new Vector3(mosPos.x, mosPos.y, 0), ballSpawner.transform.localRotation);
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
