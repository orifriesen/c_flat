using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
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
    public void checkSelf() {
            LineRenderer lr = this.GetComponent<LineRenderer>();
            if(!lr.isVisible){
                Destroy(this.gameObject);
            }
            Vector3 extents = lr.bounds.extents; 
            if(extents.x == extents.y && extents.x  == extents.z && extents.z == extents.y){
                Destroy(this.gameObject);
            }
            
    }
}

