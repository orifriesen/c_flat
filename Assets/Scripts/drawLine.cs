using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    Vector3 initMousePos, finalMousePos;
    public LineRenderer line;
    
    public EdgeCollider2D collider;

    
    public List<lineScript> musicLines = new List<lineScript>();


    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initMousePos.z = Camera.main.nearClipPlane;
            
            LineRenderer lineRender = Instantiate(line);
            

            musicLines.Add(new lineScript(lineRender, Instantiate(collider), musicLines.Count));
        }

        if(Input.GetMouseButton(0)) {
            finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            finalMousePos.z = Camera.main.nearClipPlane;

            musicLines.Last().lineRenderer.SetPosition(0, initMousePos);
            musicLines.Last().lineRenderer.SetPosition(1, finalMousePos);

            musicLines.Last().edgeCollider2D.SetPoints(new List<Vector2>(){initMousePos, finalMousePos});
        }

        if(Input.GetMouseButtonDown(1)){

        }
    }

    public void DestroyAll(){
        for(int i=0; i<musicLines.Count; i++){
            musicLines[i].Destroy();
        }
        musicLines.Clear();
    }

    public void DestroyOne(int n){
        musicLines[n].Destroy();
        musicLines.RemoveAt(n);
    }

}
