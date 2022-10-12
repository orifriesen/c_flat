using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{ 
    public Button resetButton;
    public BallSpawner ballSpawner;
    public Slider gravitySlider;
    private drawLine lineDrawer;
    private int UILayer;
    private bool isButtonDownOnUI = false;
    
    void Start(){
        resetButton.onClick.AddListener(ResetOnClick);
        lineDrawer = GetComponent<drawLine>();
        UILayer = LayerMask.NameToLayer("UI");
    }

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
            destroyIfAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }else if(Input.GetKeyDown("b") && !isButtonDownOnUI){
            Vector3 mosPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BallSpawner b = Instantiate(ballSpawner, new Vector3(mosPos.x, mosPos.y, 0), ballSpawner.transform.localRotation);
        }
        Physics2D.gravity = new Vector3(0, -gravitySlider.value, 0);
    }
    void ResetOnClick(){
            GameObject[] allBalls = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in allBalls) {
                Destroy(ball);
            }
            GameObject[] allBallSpawners = GameObject.FindGameObjectsWithTag("BallSpawner");
            foreach (GameObject bs in allBallSpawners){
                Destroy(bs);
            }
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

    void destroyIfAt(Vector2 pos){
        lineDrawer.destroyIfAt(pos);
        destroyBallSpawnerIfAt(pos);
    }
    void destroyBallSpawnerIfAt(Vector2 pos){
        GameObject[] allBallSpawners = GameObject.FindGameObjectsWithTag("BallSpawner");
            foreach (GameObject bs in allBallSpawners){
                if(Vector3.Distance(pos, bs.transform.position) < .30){
                    Destroy(bs);
                    break;
                }
            }
    }
}
