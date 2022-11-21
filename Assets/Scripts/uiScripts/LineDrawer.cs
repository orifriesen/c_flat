using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject line;
    public toolSelector toolSelect;

    private Vector2 initMousePos, finalMousePos;
    private List<GameObject> musicLines = new List<GameObject>();
    //starts the creation of a line
    public GameObject startLine(){
        
        initMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject l = Instantiate(line);
        musicLines.Add(l);

        musicLines.Last().GetComponent<lineScript>().SetAll(toolSelect.GetCurLineScript());
        return l;
    }

    //finishes it
    public void finishLine(){
        finalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        musicLines.Last().GetComponent<LineRenderer>().SetPosition(0, initMousePos);
        musicLines.Last().GetComponent<LineRenderer>().SetPosition(1, finalMousePos);
        musicLines.Last().GetComponent<EdgeCollider2D>().SetPoints(new List<Vector2>(){initMousePos, finalMousePos});
        musicLines.Last().GetComponent<LineRenderer>().material = toolSelector.lineMaterial;
    }

    //Doesnt set them up to be struck by balls, just to look at 
    public void lineToFrom(Vector2 one, Vector2 two, Material mat){
        
        musicLines.Add(Instantiate(line));

        musicLines.Last().GetComponent<LineRenderer>().SetPosition(0, one);
        musicLines.Last().GetComponent<LineRenderer>().SetPosition(1, two);
        musicLines.Last().GetComponent<EdgeCollider2D>().SetPoints(new List<Vector2>(){one, two});
        musicLines.Last().GetComponent<LineRenderer>().material = mat;
    }

    //destroys a line if it is at pos  
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
