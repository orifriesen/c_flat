using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider2D;

    public lineScript(LineRenderer lineRenderer, EdgeCollider2D edgeCollider2D){
        this.lineRenderer = lineRenderer;
        this.edgeCollider2D = edgeCollider2D;
    }

    public void Destroy(){
        UnityEngine.Object.Destroy(lineRenderer.gameObject);
        UnityEngine.Object.Destroy(edgeCollider2D.gameObject);
    }

    public bool isAt(Vector2 pos){
        return edgeCollider2D.bounds.Contains(pos);
    }
}
