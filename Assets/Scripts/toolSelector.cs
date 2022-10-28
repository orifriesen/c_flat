using UnityEngine;
using UnityEngine.UI;
using System;


public class toolSelector : MonoBehaviour
{
    //TODO turn this into an array based approach for code neatness
    public Button guitar1, guitar2, guitar3, piano1, piano2, piano3, bass1, bass2, bass3;
    public Material guitar1m, guitar2m, guitar3m, piano1m, piano2m, piano3m, bass1m, bass2m, bass3m;
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
        bass1.onClick.AddListener(Bass1Click);
        bass2.onClick.AddListener(Bass2Click);
        bass3.onClick.AddListener(Bass3Click);
        lineMaterial = piano2m;
        piano2.interactable = false;
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
    void Bass1Click() {
        lineMaterial = bass1m;
        select(bass1);
    }
    void Bass2Click() {
        lineMaterial = bass2m;
        select(bass2);
    }
    void Bass3Click() {
        lineMaterial = bass3m;
        select(bass3);
    }

    void select(Button button) {
        guitar1.interactable = true;
        guitar2.interactable = true;
        guitar3.interactable = true;
        piano1.interactable = true;
        piano2.interactable = true;
        piano3.interactable = true;
        bass1.interactable = true;
        bass2.interactable = true;
        bass3.interactable = true;
        button.interactable = false;
    }

    public double getColorInt(){
        if(lineMaterial == guitar1m){
            return 2;
        }if(lineMaterial == guitar2m){
            return 3;
        }if(lineMaterial == guitar3m){
            return 4;
        }if(lineMaterial == piano1m){
            return 1.4;
        }if(lineMaterial == piano2m){
            return 3;
        }if(lineMaterial == piano3m){
            return 4.6;
        }
        throw new Exception("this should'nt happen, toolSelector getColorInt()");
    }

    public Color getColor(){
        if(lineMaterial == guitar1m){
            return guitar1.GetComponent<Image>().color;
        }if(lineMaterial == guitar2m){
            return guitar2.GetComponent<Image>().color;;
        }if(lineMaterial == guitar3m){
            return guitar3.GetComponent<Image>().color;;
        }if(lineMaterial == piano1m){
            return piano1.GetComponent<Image>().color;;
        }if(lineMaterial == piano2m){
            return piano2.GetComponent<Image>().color;;
        }if(lineMaterial == piano3m){
            return piano3.GetComponent<Image>().color;;
        }if(lineMaterial == bass1m){
            return bass1.GetComponent<Image>().color;;
        }if(lineMaterial == bass2m){
            return bass2.GetComponent<Image>().color;;
        }if(lineMaterial == bass3m){
            return bass3.GetComponent<Image>().color;;
        }
        throw new Exception("this should'nt happen, toolSelector getColor()");
    }
}
