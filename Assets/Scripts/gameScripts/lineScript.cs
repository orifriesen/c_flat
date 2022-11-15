using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public double colorInt;
    public int instrumentInt;
    public Color color;
    public Material material;

    public void SetAll(lineScriptDataOnly ls){
        colorInt = ls.colorInt;
        instrumentInt = ls.instrumentInt;
        color = ls.color;
        material = ls.material;
    }
}

