using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    public Button pauseButton;
    public Button playButton;
    public Button stopButton;
    void Start(){
        playButton.onClick.AddListener(PlayOnClick);
        pauseButton.onClick.AddListener(PauseOnClick);
        stopButton.onClick.AddListener(StopOnClick);
    }
    void PlayOnClick(){
		Debug.Log ("You have clicked the play button!");
	}
    void PauseOnClick(){
		Debug.Log ("You have clicked the pause button!");
	}
    void StopOnClick(){
		Debug.Log ("You have clicked the stop button!");
	}
}
