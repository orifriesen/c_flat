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
    public LineDrawer lineScript;
    public Material purple;
    private BackGround backGroundMotor;

    private Vector3 textPos;

    private Vector2[] vectorsOne = new Vector2[]{new Vector2(-6, 1)};
    private Vector2[] vectorsTwo= new Vector2[]{new Vector2(6, 1)};
    private Material[] mat;

    void Start(){
        Time.timeScale = 1;
        mat = new Material[]{purple};
        playButton.onClick.AddListener(Play);
        infoButton.onClick.AddListener(Info);
        helpButton.onClick.AddListener(Help);
        textPos = new Vector3(0, -Screen.height/5f, 0);

        for(int i=0; i<vectorsOne.Length; i++){
            lineScript.lineToFrom(vectorsOne[i], vectorsTwo[i], mat[i]);
        }

    }

    void Update() {
        if(backGroundMotor == null){
            backGroundMotor = GameObject.FindGameObjectWithTag("Background").GetComponent<BackGround>();
        }
    }

    void destroyAllTemp(){
        GameObject[] lst = GameObject.FindGameObjectsWithTag("TempUI");
            foreach(GameObject gameObject in lst){
                Destroy(gameObject);
            }
    }
    void Play(){
        backGroundMotor.onMove();
        SceneManager.LoadScene("MainScene");
        backGroundMotor.changeAlphaToReach(0.6f);
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
