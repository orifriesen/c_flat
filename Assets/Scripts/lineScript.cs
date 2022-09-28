using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("delete");
        }
    }
}
