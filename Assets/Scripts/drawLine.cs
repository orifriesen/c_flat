using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    Vector2 initMousePos, finalMousePos;
    public LineRenderer line;
    
    public new EdgeCollider2D collider;

    
    public List<lineScript> musicLines = new List<lineScript>();

    public void startLine(){
        initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musicLines.Add(new lineScript(Instantiate(line), Instantiate(collider)));
    }

    public void finishLine(){
        finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musicLines.Last().lineRenderer.SetPosition(0, initMousePos);
        musicLines.Last().lineRenderer.SetPosition(1, finalMousePos);
        musicLines.Last().edgeCollider2D.SetPoints(new List<Vector2>(){initMousePos, finalMousePos});
    }

    public void destroyIfAt(Vector2 pos){
        int i=0;
        foreach(lineScript lineScript in musicLines){
            if(lineScript.isAt(pos)){
                DestroyOne(i);
                break;
            }
            i++;
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
