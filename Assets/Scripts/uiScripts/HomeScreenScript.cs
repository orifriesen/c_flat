     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.SceneManagement;
    using UnityEngine.UI;
public class HomeScreenScript : MonoBehaviour
{   

    public Button playButton;
    public Button infoButton;
    public Button helpButton;

    public GameObject helpText;
    public GameObject infoText;

    private Vector3 textPos;

    public drawLine lineScript;
    public Material purple;

    private Vector2[] vectorsOne = new Vector2[]{new Vector2(-6, 1)};
    private Vector2[] vectorsTwo= new Vector2[]{new Vector2(6, 1)};
    private Material[] mat;

    public backgroundmotor backgroundmotor;
    void Start(){
        mat = new Material[]{purple};
        playButton.onClick.AddListener(Play);
        infoButton.onClick.AddListener(Info);
        helpButton.onClick.AddListener(Help);
        textPos = new Vector3(0, -Screen.height/5f, 0);

        for(int i=0; i<vectorsOne.Length; i++){
            lineScript.lineToFrom(vectorsOne[i], vectorsTwo[i], mat[i]);
        }

    }

    void destroyAllTemp(){
        GameObject[] lst = GameObject.FindGameObjectsWithTag("TempUI");
            foreach(GameObject gameObject in lst){
                Destroy(gameObject);
            }
    }
    void Play(){

        SceneManager.LoadScene("MainScene");
    }
    void Info(){
        destroyAllTemp();
        GameObject go = Instantiate(infoText, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
        go.transform.position = textPos;
        go.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
    }
    void Help(){
        destroyAllTemp();
        GameObject go = Instantiate(helpText, new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
        go.transform.position = textPos;
        go.transform.SetParent(GameObject.FindGameObjectWithTag("MainCanvas").transform, false);
    }
}
