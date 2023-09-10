using System.Diagnostics;
using System.Data;
using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{

    #region UI
        public GameObject TextUI;
        public GameObject ImageUI;
    #endregion

    #region Building's prefabs
        public GameObject Home;
        public GameObject Fabric;
        public GameObject Economic;
    #endregion

    #region PlayerInfo
        public GameObject Player;
        private Transform myTransform;

        private float Cash;
        private float Material;
    #endregion

    #region additionally
    private RaycastHit Place;
    #endregion

    void Start()
    {
        myTransform = transform;                    // sets myTransform to this GameObject.transform
        ImageUI.SetActive(false);
        TextUI.SetActive(false);
        
    }
 
    void Update()
    {
        Cash = Player.GetComponent<PlayerScript>().nowCash;
        Material = Player.GetComponent<PlayerScript>().nowMaterial;
        
        // Z X C
        if(Place.collider){
        if (Input.GetKeyUp(KeyCode.Z)){
            
            if(Place.collider.tag == "Place" && Place.collider.GetComponent<Place_script>().canBuy == true){
                if(Cash-1000>=0 && Material-1000>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - 1000;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - 1000;

                    Instantiate(Home, Place.collider.transform.position+new Vector3(0,-1.5f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "Home";
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.X)){
            if(Place.collider.tag == "Place" && Place.collider.GetComponent<Place_script>().canBuy == true){
                if(Cash-1000>=0 && Material-1000>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - 1000;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - 1000;

                    Instantiate(Fabric, Place.collider.transform.position+new Vector3(+0.5f,-1.5f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "Fabric";
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.C)){
            if(Place.collider.tag == "Place" && Place.collider.GetComponent<Place_script>().canBuy == true){
                if(Cash-1000>=0 && Material-1000>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - 1000;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - 1000;

                    Instantiate(Economic, Place.collider.transform.position+new Vector3(0,-1.2f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "Economic";
                }
            }
        }
        }
        // END Z X C
        Plane playerPlane = new Plane(Vector3.up, myTransform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,50f))
            {
                if(hit.collider.tag != "cantShow"){
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                    TextUI.GetComponent<UnityEngine.UI.Text>().text=interactable.GetDescription();
                    ImageUI.SetActive(true);
                    TextUI.SetActive(true);
                    if (Input.GetMouseButtonDown(0)&& GUIUtility.hotControl == 0)
                    { 
                        Place = hit;
                    }
                }
                else{
                    TextUI.GetComponent<UnityEngine.UI.Text>().text="";
                    ImageUI.SetActive(false);
                    TextUI.SetActive(false);
              

            }
        }
    }
}

