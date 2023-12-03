using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowey : MonoBehaviour, IEsterEgg
{
    public AudioSource Sound;
    public GameObject TextCloud;
    void Start()
    {
        TextCloud.SetActive(false);
    }
    public void EsterEggActive(){
        Sound.Play();
        TextCloud.SetActive(true);
        Invoke("wait",1.2f);
    }
    private void wait(){
        Sound.Stop();
        TextCloud.SetActive(false);
    }
}
