using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class toolSelector : MonoBehaviour
{
    public Button white, red, orange, yellow, green, blue, purple;
    public Material whiteLine, redLine, orangeLine, yellowLine, greenLine, blueLine, purpleLine;
    public static Material lineMaterial;
    // Start is called before the first frame update
    void Start()
    {
        white.onClick.AddListener(WhiteClick);
        red.onClick.AddListener(RedClick);
        orange.onClick.AddListener(OrangeClick);
        yellow.onClick.AddListener(YellowClick);
        green.onClick.AddListener(GreenClick);
        blue.onClick.AddListener(BlueClick);
        purple.onClick.AddListener(PurpleClick);
        lineMaterial = whiteLine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhiteClick() {
        lineMaterial = whiteLine;
    }
    void RedClick() {
        lineMaterial = redLine;
    }
    void OrangeClick() {
        lineMaterial = orangeLine;
    }
    void YellowClick() {
        lineMaterial = yellowLine;
    }
    void GreenClick() {
        lineMaterial = greenLine;
    }
    void BlueClick() {
        lineMaterial = blueLine;
    }
    void PurpleClick() {
        lineMaterial = purpleLine;
    }
}
