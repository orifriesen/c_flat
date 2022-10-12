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
        white.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WhiteClick() {
        lineMaterial = whiteLine;
        select(white);
    }
    void RedClick() {
        lineMaterial = redLine;
        select(red);
    }
    void OrangeClick() {
        lineMaterial = orangeLine;
        select(orange);
    }
    void YellowClick() {
        lineMaterial = yellowLine;
        select(yellow);
    }
    void GreenClick() {
        lineMaterial = greenLine;
        select(green);
    }
    void BlueClick() {
        lineMaterial = blueLine;
        select(blue);
    }
    void PurpleClick() {
        lineMaterial = purpleLine;
        select(purple);
    }

    void select(Button button) {
        white.interactable = true;
        red.interactable = true;
        orange.interactable = true;
        yellow.interactable = true;
        green.interactable = true;
        blue.interactable = true;
        purple.interactable = true;
        button.interactable = false;
    }
}
