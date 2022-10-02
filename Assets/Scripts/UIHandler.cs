using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{ 
    // public enum PlayCondition {PLAY, PAUSE};
    // public Button pauseButton;
    // public Button playButton;
    // public Button stopButton;
    // private PlayCondition playCondition = PlayCondition.PLAY;

    public Button resetButton;
    public drawLine lineScript;

    
    void Start(){
        // playButton.onClick.AddListener(PlayOnClick);
        // pauseButton.onClick.AddListener(PauseOnClick);
        // stopButton.onClick.AddListener(StopOnClick);

        resetButton.onClick.AddListener(ResetOnClick);
    }

    void Update(){
        
    }
    void ResetOnClick(){
		//   playCondition = PlayCondition.PAUSE;
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls) {
                Destroy(ball);
            }
            lineScript.DestroyAll();    
	}

    // public PlayCondition GetPlayCondition(){
    //   return playCondition;
    // }
}
