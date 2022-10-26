using UnityEngine;
using UnityEngine.UI;
using System;


public class toolSelector : MonoBehaviour
{
    //TODO turn this into an array based approach for code neatness
    public Button guitar1, guitar2, guitar3, piano1, piano2, piano3;
    public Material guitar1m, guitar2m, guitar3m, piano1m, piano2m, piano3m;
    public static Material lineMaterial;
    // Start is called before the first frame update
    void Start()
    {
        guitar1.onClick.AddListener(Guitar1Click);
        guitar2.onClick.AddListener(Guitar2Click);
        guitar3.onClick.AddListener(Guitar3Click);
        piano1.onClick.AddListener(Piano1Click);
        piano2.onClick.AddListener(Piano2Click);
        piano3.onClick.AddListener(Piano3Click);
        lineMaterial = piano1m;
        piano1.interactable = false;
    }

    void Guitar1Click() {
        lineMaterial = guitar1m;
        select(guitar1);
    }
    void Guitar2Click() {
        lineMaterial = guitar2m;
        select(guitar2);
    }
    void Guitar3Click() {
        lineMaterial = guitar3m;
        select(guitar3);
    }
    void Piano1Click() {
        lineMaterial = piano1m;
        select(piano1);
    }
    void Piano2Click() {
        lineMaterial = piano2m;
        select(piano2);
    }
    void Piano3Click() {
        lineMaterial = piano3m;
        select(piano3);
    }

    void select(Button button) {
        guitar1.interactable = true;
        guitar2.interactable = true;
        guitar3.interactable = true;
        piano1.interactable = true;
        piano2.interactable = true;
        piano3.interactable = true;
        button.interactable = false;
    }

    public int getColorInt(){
        if(lineMaterial == guitar1){
            return 0;
        }if(lineMaterial == guitar2){
            return 1;
        }if(lineMaterial == guitar3){
            return 2;
        }if(lineMaterial == piano1){
            return 3;
        }if(lineMaterial == piano2){
            return 4;
        }if(lineMaterial == piano3){
            return 5;
        }
        throw new Exception("this should'nt happen, toolSelector getColorInt");
    }
}
