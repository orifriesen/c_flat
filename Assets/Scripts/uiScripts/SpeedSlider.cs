using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedSlider : MonoBehaviour
{

    private BallSpawner ballSpawner;
    public void setValFromDelay(float delay){
        this.gameObject.GetComponent<Slider>().value = delay /3.0f -.1f;
    }
    public void SetBallSpawner(BallSpawner bs){
        ballSpawner = bs;
    }
    private void Update() {
        ballSpawner.delay = (this.gameObject.GetComponent<Slider>().value + .1f)*3.0f;
    }
}
