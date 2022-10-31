using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class UIHandler : MonoBehaviour
{ 
    public Button resetButton;
    public BallSpawner ballSpawner;
    public Slider gravitySlider;
    public Slider bloomSlider;
    public Toggle playButton;
    
    public GameObject VolumeObj;
    private Volume volume;
    private drawLine lineDrawer;
    private int UILayer;
    private bool isButtonDownOnUI = false;
    

    void Start(){
        resetButton.onClick.AddListener(ResetOnClick);

        bloomSlider.onValueChanged.AddListener(delegate {bloomChange();});
        gravitySlider.onValueChanged.AddListener(delegate {gravityChange();});

        lineDrawer = GetComponent<drawLine>();
        UILayer = LayerMask.NameToLayer("UI");
        volume = VolumeObj.GetComponent<Volume>();
    }

    //calls the relevant scripts each frame
    void Update(){
        if(Input.GetMouseButton(0) && IsPointerOverUIElement()) {
            isButtonDownOnUI = true;
        }
        if(isButtonDownOnUI == true && Input.GetMouseButtonUp(0)) {
            isButtonDownOnUI = false;
        }
        
        if (Input.GetMouseButtonDown(0) && !isButtonDownOnUI) {
            lineDrawer.startLine();
        }else if(Input.GetMouseButton(0) && !isButtonDownOnUI){
            lineDrawer.finishLine();
        }else if(Input.GetMouseButtonDown(1) && !isButtonDownOnUI){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineDrawer.destroyIfAt(pos);
            destroyAllOfTag("TempUI");
            createUIIfAt(pos);
        }else if(Input.GetKeyDown("b") && !isButtonDownOnUI){
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallSpawner b = Instantiate(ballSpawner, new Vector3(mosPos.x, mosPos.y, 0), ballSpawner.transform.localRotation);
        }


        if(Input.GetKeyDown(KeyCode.Space) && playButton.isOn) {
            playButton.isOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !playButton.isOn) {
            playButton.isOn = true;
        }

        if(playButton.isOn) {
            Time.timeScale = 1;
        }else {
            Time.timeScale = 0;
        }

        
    }
    //Destroys all balls lines and ball spawners
    void ResetOnClick(){
            destroyAllOfTag("Ball");
            destroyAllOfTag("BallSpawner");
            destroyAllOfTag("TempUI");
            lineDrawer.DestroyAll();   
	}
    
    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
 
 
    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
    {
        for (int index = 0; index < eventSystemRaycastResults.Count; index++)
        {
            RaycastResult curRaycastResult = eventSystemRaycastResults[index];
            if (curRaycastResult.gameObject.layer == UILayer)
                return true;
        }
        return false;
    }
 
 
    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    
    void createUIIfAt(Vector2 pos){
        GameObject[] allBallSpawners = GameObject.FindGameObjectsWithTag("BallSpawner");
            foreach (GameObject bs in allBallSpawners){
                if(Vector3.Distance(pos, bs.transform.position) < .30){
                    bs.GetComponent<BallSpawner>().CreateButtons();
                    break;
                }
            }
    }

    void bloomChange(){
        Bloom bloom;
        volume.profile.TryGet<Bloom>(out bloom);
        bloom.intensity.value = (Mathf.Pow(bloomSlider.value, 2.3f) * .01f);
    }

    void gravityChange(){
        Physics2D.gravity = new Vector3(0, -gravitySlider.value, 0);
    }

    void destroyAllOfTag(string tag){
        GameObject[] lst = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject gameObject in lst){
                Destroy(gameObject);
            }
    }
}
