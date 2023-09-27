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
        // if(Input.GetKey(KeyCode.W))
        // {
        //     player.transform.position += player.transform.forward * speed * Time.deltaTime;
        // }
        // if(Input.GetKey(KeyCode.S))
        // {
        //     player.transform.position -= player.transform.forward * speed * Time.deltaTime;
        // }
        // if(Input.GetKey(KeyCode.D))
        // {
        //     player.transform.position += player.transform.right * speed * Time.deltaTime;
        //     }
        // if(Input.GetKey(KeyCode.A))
        // {
        //     player.transform.position -= player.transform.right * speed * Time.deltaTime;
        // }
        // if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
        //     player_t.transform.rotation = Quaternion.Euler(0, -90-45, 0);
        // }
        // else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
        //     player_t.transform.rotation = Quaternion.Euler(0, 90+45, 0);
        // }
        // else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)){
        //     player_t.transform.rotation = Quaternion.Euler(0, -45, 0);
        // }
        // else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
        //     player_t.transform.rotation = Quaternion.Euler(0, +45, 0);
        // }
        // else if(Input.GetKey(KeyCode.W)){
        //     player_t.transform.rotation = Quaternion.Euler(0, 180, 0);
        // }
        // else if(Input.GetKey(KeyCode.D)){
        //     player_t.transform.rotation = Quaternion.Euler(0, -90, 0);
        // }
        // else if(Input.GetKey(KeyCode.A)){
        //     player_t.transform.rotation = Quaternion.Euler(0, 90, 0);
        // }
        // else if(Input.GetKey(KeyCode.S)){
        //     player_t.transform.rotation = Quaternion.Euler(0, 0, 0);
        // }
    }
    public void update_UI(){
        TextCash.GetComponent<UnityEngine.UI.Text>().text=nowCash.ToString();
        TextMaterial.GetComponent<UnityEngine.UI.Text>().text=nowMaterial.ToString();
    }
}
