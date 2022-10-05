using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{ 
    public Button resetButton;

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
            // Instantiate(ballSpawner, Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0,0,0,1));
        }
    }
    void ResetOnClick(){
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls) {
                Destroy(ball);
            }
            lineDrawer.DestroyAll();    
	}

}
