
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;
    public void PlayNewGame(){
        PlayerPrefs.SetInt("NewGame",0);
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }
    public void PlayGame(){
        if(PlayerPrefs.GetInt("NewGame")==1){
            LoadingScreen.SetActive(true);
            StartCoroutine(LoadAsync());
        }
    }
    IEnumerator LoadAsync(){
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        loadAsync.allowSceneActivation = false;
        while(!loadAsync.isDone){
            scale.value = loadAsync.progress;
            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation){
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
