using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    //private GameObject SelectedObject;
    private float Cash;
    public GameObject Player;
    public GameObject Camera;
    private RaycastHit Place;
    public GameObject Panel;
    public GameObject viewObjectEconomic;
    public GameObject viewObjectHouse;
    public GameObject viewObjectFabric;
    private string namePlace="";

    public GameObject LeftButton;
    public GameObject LeftButtonName;
    public GameObject LeftButtonDesc;

    public GameObject RightButton;
    public GameObject RightButtonName;
    public GameObject RightButtonDesc;

    void Start(){
        //Panel = this.gameObject;
        Panel.SetActive(false);

    }

    void Update()
    {
        Cash = Player.GetComponent<PlayerScript>().nowCash;
        Place = Camera.GetComponent<MouseScript>().Place;
        if(Place.collider.GetComponent<Place_script>()){ 
            namePlace=Place.collider.GetComponent<Place_script>().namethis;
            if(namePlace=="Shop"){
                viewObjectSetActive(true,false,false);
            } else if (namePlace=="House") {
                viewObjectSetActive(false,true,false);
            } else if (namePlace=="Fabric") {
                viewObjectSetActive(false,false,true);
            }
            LeftButtonName.GetComponent<UnityEngine.UI.Text>().text=Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().descUpgradeModiferOne[0];
            LeftButtonDesc.GetComponent<UnityEngine.UI.Text>().text=Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().descUpgradeModiferOne[1];
            RightButtonName.GetComponent<UnityEngine.UI.Text>().text=Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().descUpgradeModiferTwo[0];
            RightButtonDesc.GetComponent<UnityEngine.UI.Text>().text=Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().descUpgradeModiferTwo[1];
        }
    }
    private bool canBuy(float need){
        if (Cash-need>=0){
            return true;
        } else {
            return false;
        }
    }
    public void funLeftButton(){
        if(canBuy(Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().priceUpgradeModifOne)){
            Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().UpgradeModifer();
            Player.GetComponent<PlayerScript>().nowCash=Player.GetComponent<PlayerScript>().nowCash-Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().priceUpgradeModifOne;
        }
    }
    public void funRightButton(){
        if(canBuy(Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().priceUpgradeModifTwo)){
            Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().UpgradeModiferTwo();
            Player.GetComponent<PlayerScript>().nowCash=Player.GetComponent<PlayerScript>().nowCash-Place.collider.transform.GetChild(1).transform.GetComponent<IBuilding>().priceUpgradeModifTwo;
        
        }
    }
    public void OpenUpgradeMenu(){Panel.SetActive(true);}
    public void CloseUpgradeMenu(){Panel.SetActive(false);}
    private void viewObjectSetActive(bool eco,bool hos,bool fab){
        viewObjectEconomic.SetActive(eco);
        viewObjectHouse.SetActive(hos);
        viewObjectFabric.SetActive(fab);
    }
}
