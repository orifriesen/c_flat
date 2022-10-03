using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{ 
    public Button resetButton;
    private drawLine lineScript;
    
    
    void Start(){
        lineScript = GetComponent<drawLine>();
        resetButton.onClick.AddListener(ResetOnClick);
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            lineScript.startLine();
        }else if(Input.GetMouseButton(0)){
            lineScript.finishLine();
        }else if(Input.GetMouseButtonDown(1)){
            lineScript.destroyIfAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
    void ResetOnClick(){
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls) {
                Destroy(ball);
            }

            lineScript.DestroyAll();    
	}
}
