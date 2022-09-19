using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private float lastSpawn = 0.0f;
    public float delay;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > delay + lastSpawn){
            Instantiate(ball,  this.transform.localPosition, this.transform.localRotation);
            lastSpawn=Time.time;
    }
    }
}
