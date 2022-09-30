using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
{

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("delete");
            Destroy(gameObject);
        }
    }
}
