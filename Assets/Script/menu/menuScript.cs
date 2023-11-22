using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    void Start(){
        //Screen.SetResolution(Screen.width, Screen.height, true, 60);
    }
    public void Scenes(int numberScenes){
        SceneManager.LoadScene(numberScenes);
    }
}
