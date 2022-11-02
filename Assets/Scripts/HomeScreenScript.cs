     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.SceneManagement;
    using UnityEngine.UI;
public class HomeScreenScript : MonoBehaviour
{   

    public Button playButton;
    void Start(){
        playButton.onClick.AddListener(Play);
    }
    void Play(){
        SceneManager.LoadScene("MainScene");
    }
}
