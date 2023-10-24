using System.Diagnostics;
using System.Data;
using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{

    #region UI
        public GameObject TextUI;
        public GameObject ImageUI;
        public GameObject SelObj;

        public GameObject btnCanvasUpgrade;
        public GameObject btnBuy;
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
        public RaycastHit Place;
    #endregion

    #region
        public GameObject   BuyMenu;
        public GameObject[] BuyList;
    #endregion

    void Start()
    {
        myTransform = transform;                    // sets myTransform to this GameObject.transform
        SelObj.SetActive(false);
    }
 
    void Update()
    {
        Cash = Player.GetComponent<PlayerScript>().nowCash;
        Material = Player.GetComponent<PlayerScript>().nowMaterial;
        if(Place.collider){
            if(Place.collider.tag != "cantShow"){
                TextUI.GetComponent<UnityEngine.UI.Text>().text=Place.collider.GetComponent<IInteractable>().GetDescription();
                if(Place.collider.GetComponent<Place_script>().canModif){
                        btnCanvasUpgrade.SetActive(true);
                        btnBuy.SetActive(false);
                } else {
                        btnCanvasUpgrade.SetActive(false);
                        btnBuy.SetActive(true);
                }
            }
        }
        Plane playerPlane = new Plane(Vector3.up, myTransform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1) && GUIUtility.hotControl == 0)//if Click
        { 
            if (Physics.Raycast(ray, out hit,50f))//if Raycast
            {
                if(hit.collider.tag != "cantShow"){//if can show object
                    Place = hit;
                    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                    TextUI.GetComponent<UnityEngine.UI.Text>().text=interactable.GetDescription();
                    SelObj.SetActive(true);
                }//end(if can show object)
                else{//else(if can show object)
                    TextUI.GetComponent<UnityEngine.UI.Text>().text="";
                    SelObj.SetActive(false);
                }//end else(if can show object)
            }//end(if Raycast)
            else{//else (if Raycast)
                TextUI.GetComponent<UnityEngine.UI.Text>().text="";
                SelObj.SetActive(false);
        }//end(else (if Raycast))
        }//end(if click)
        //SelObj
        
        //Button btn = yourButton.GetComponent<Button>();
        //btn.onClick.AddListener(TaskOnClick);
        //2 3
        //Up Sell

        //btnSell.onClick.AddListener(sell);
    }
    public void sell(){
        if(Place.collider){
            if(Place.collider.transform.GetChild(1).transform.GetComponent<BuildingEconomic>()){
               
                Place.collider.transform.GetChild(1).transform.GetComponent<BuildingEconomic>().SellPlace();

            } else if(Place.collider.transform.GetChild(1).transform.GetComponent<BuildingFabric>()){
                
                Place.collider.transform.GetChild(1).transform.GetComponent<BuildingFabric>().SellPlace();

            } else if(Place.collider.transform.GetChild(1).transform.GetComponent<BuildingHouse>()){

                Place.collider.transform.GetChild(1).transform.GetComponent<BuildingHouse>().SellPlace();

            }
        }
        }
    public void Buy(){
        if(Place.collider){
            if(Place.collider.GetComponent<Place_script>().canBuy == true){
                BuyMenu.SetActive(true);
            }else{
                BuyMenu.SetActive(false);
            }
        }
    }

    

    public void CloseMenu(){
        BuyMenu.SetActive(false);
    }
}

