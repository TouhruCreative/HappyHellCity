using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool itTime = true;
    public GameObject PauseObject;
    public GameObject SettingsInPauseObject;
    void Start(){
        TimeGo();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(itTime){
                TimeStop();
            } else{
                TimeGo();
            }
        } 
    }
    public void TimeGo(){
        itTime = true;
        Time.timeScale = 1.0f;
        PauseObject.SetActive(false);
        SettingsInPauseObject.SetActive(false);
    }
    public void TimeStop(){
        itTime = false;
        Time.timeScale = 0f;
        PauseObject.SetActive(true);
    }
}
