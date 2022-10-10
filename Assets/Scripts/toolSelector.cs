using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class toolSelector : MonoBehaviour
{
    public Button white, red;
    // Start is called before the first frame update
    void Start()
    {
        white.onClick.AddListener(WhiteClick);
        red.onClick.AddListener(RedClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhiteClick() {
        Debug.Log("white");
    }
    void RedClick() {
        Debug.Log("red");
    }
}
