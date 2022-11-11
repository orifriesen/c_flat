using UnityEngine;
using UnityEngine.UI;
using System;


public class toolSelector : MonoBehaviour
{
    //TODO turn this into an array based approach for code neatness
    public Button guitar1, guitar2, guitar3, piano1, piano2, piano3, bass1, bass2, bass3, drum1, drum2, drum3;
    public Material guitar1m, guitar2m, guitar3m, piano1m, piano2m, piano3m, bass1m, bass2m, bass3m, drum1m, drum2m, drum3m;


    private lineScriptDataOnly[] lineScripts;
    private Material[] materials;
    private Button[] Buttons;
    public static Material lineMaterial;
    private int linePos;
    // Start is called before the first frame update
    void Start()
    {
        Buttons = new Button[] {piano1, piano2, piano3, guitar1, guitar2, guitar3, bass1, bass2, bass3, drum1, drum2, drum3};
        lineScripts = new lineScriptDataOnly[Buttons.Length];
        materials = new Material[] {piano1m, piano2m, piano3m, guitar1m, guitar2m, guitar3m, bass1m, bass2m, bass3m, drum1m, drum2m, drum3m};

        for(int i=0; i<Buttons.Length; i++){
            int i1 = i;
            Buttons[i].onClick.AddListener(delegate{ButtonClicked(i1);});
            lineScripts[i] = new lineScriptDataOnly();
            lineScripts[i].material = materials[i];
            lineScripts[i].instrumentInt = i;
            if((i+1) % 3 == 1){
                lineScripts[i].colorInt = 1.4;
            }else if((i+1) % 3 == 2){
                lineScripts[i].colorInt = 3;
            }else if((i+1) % 3 == 0){
                lineScripts[i].colorInt = 4.6;
            }
            lineScripts[i].color = Buttons[i].GetComponent<Image>().color;
        }

        lineMaterial = piano2m;
        linePos = 2;
        piano2.interactable = false;

    }

    void ButtonClicked(int n){
        lineMaterial = lineScripts[n].material;
        linePos = n;
        select(Buttons[n]);
    }

    void select(Button button) {
        foreach(Button b in Buttons){
            b.interactable = true;
        }
        button.interactable = false;
    }

    public lineScriptDataOnly GetCurLineScript(){
        return lineScripts[linePos];
    }
}

