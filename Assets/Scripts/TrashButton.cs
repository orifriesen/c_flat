using UnityEngine;
using UnityEngine.UI;
public class TrashButton : MonoBehaviour
{ 

    private GameObject ballSpawner;
    private GameObject slider;
    private void Start() {
       Button btn = this.GetComponent<Button>();
       btn.onClick.AddListener(Trash);
    }

    public void SetBallSpawner(GameObject bs){
        ballSpawner = bs;
    }
    public void setSlider(GameObject s){
        slider = s;
    }
    private void Trash(){
        Destroy(ballSpawner);
        Destroy(this.gameObject);
        Destroy(slider);
    }
}