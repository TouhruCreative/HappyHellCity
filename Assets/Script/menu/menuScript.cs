using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public void Scenes(int numberScenes){
        SceneManager.LoadScene(numberScenes);
    }
}
