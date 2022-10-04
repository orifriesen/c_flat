using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    Vector2 initMousePos, finalMousePos;
    public GameObject line;

    
    public List<GameObject> musicLines = new List<GameObject>();

    public void startLine(){
        initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musicLines.Add(Instantiate(line));
    }

    public void finishLine(){
        finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musicLines.Last().GetComponent<LineRenderer>().SetPosition(0, initMousePos);
        musicLines.Last().GetComponent<LineRenderer>().SetPosition(1, finalMousePos);
        musicLines.Last().GetComponent<EdgeCollider2D>().SetPoints(new List<Vector2>(){initMousePos, finalMousePos});
    }

    public void destroyIfAt(Vector2 pos){
        int i=0;
        foreach(GameObject l in musicLines){
            if(l.GetComponent<EdgeCollider2D>().bounds.Contains(pos)){
                DestroyOne(i);
                break;
            }
            i++;
        }

    }

    public void DestroyAll(){
        for(int i=0; i<musicLines.Count; i++){
            Destroy(musicLines[i]);
        }
        musicLines.Clear();
    }

    public void DestroyOne(int n){
        Destroy(musicLines[n]);
        musicLines.RemoveAt(n);
    }


}
