using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedSlider : MonoBehaviour
{

    private BallSpawner ballSpawner;
    public void setValFromDelay(float delay){
        this.gameObject.GetComponent<Slider>().value = (float)(delay /3.0 -.1);
    }
    public void SetBallSpawner(BallSpawner bs){
        ballSpawner = bs;
    }
    private void Update() {
        ballSpawner.delay = (float)(this.gameObject.GetComponent<Slider>().value + .1)*3;
    }
}
