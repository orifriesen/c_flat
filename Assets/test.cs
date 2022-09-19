using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<Renderer>().isVisible){
            Destroy(gameObject);
        }
    }
<<<<<<< Updated upstream:Assets/test.cs
=======
    
    private void OnCollisionEnter2D(Collision2D other) {
        other.collider.SendMessage("PlaySound");
    }
>>>>>>> Stashed changes:Assets/Scripts/Ball.cs
}
