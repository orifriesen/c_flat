using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;
    public int pos;


    public lineScript(LineRenderer lineRenderer, EdgeCollider2D edgeCollider2D, int pos){
        this.lineRenderer = lineRenderer;
        this.edgeCollider2D = edgeCollider2D;
        this.pos = pos;
    }

    public void Destroy(){
        Destroy(lineRenderer.gameObject);
        Destroy(edgeCollider2D.gameObject);
    }
}
