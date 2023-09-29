using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IInteractable
{
    public int speed = 5;
    public GameObject player;
    public GameObject player_t;

    public float maxHP = 100;
    public float nowHP = 1;
    private string colorHP;

    public float nowCash = 10000;
    public GameObject TextCash;

    public float nowMaterial = 10000;
    public GameObject TextMaterial;
    public float nowHappy=0;
    public GameObject TextHappy;
    public GameObject NN;


    public string GetDescription()
    {
        return string.Format("Is you :)");   
    }
    public void Interact(){}
    void Start()
    {
        nowHP = maxHP;
        player = (GameObject)this.gameObject;
    }

    void Update()
    {   
        update_UI();
    }
    public void update_UI(){
        TextCash.GetComponent<UnityEngine.UI.Text>().text=nowCash.ToString();
        TextMaterial.GetComponent<UnityEngine.UI.Text>().text=nowMaterial.ToString();
        TextHappy.GetComponent<UnityEngine.UI.Text>().text=nowHappy.ToString();
    }
}
