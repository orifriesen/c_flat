using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedSlider : MonoBehaviour
{

    private BallSpawner ballSpawner;
    public void setValFromDelay(float delay){
        float newValue = delay /3.0f -.1f;
        newValue = Mathf.Round(newValue*2.0f)/2.0f;
        this.gameObject.GetComponent<Slider>().value = newValue;
    }
    public void SetBallSpawner(BallSpawner bs){
        ballSpawner = bs;
    }
    private void Update() {
        float newValue = (this.gameObject.GetComponent<Slider>().value + .1f)*3.0f;
        newValue = Mathf.Round(newValue*2.0f)/2.0f;
        ballSpawner.delay = newValue;
    }
}
