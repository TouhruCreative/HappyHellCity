using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyMenu : MonoBehaviour
{
    #region GameObject for getComponent
        public GameObject Player;
        public GameObject Camera;
    #endregion
    #region Building's prefabs
        public GameObject Home;
        public GameObject Fabric;
        public GameObject Shop;
    #endregion
    #region cantBuyImage
        public GameObject imgEconmic;
        public GameObject imgHouse;
        public GameObject imgFabric;
    #endregion
    #region Private Var
        private RaycastHit Place;
        private float Cash;
        private float Material;
        #region Private Var
            private float priceCashEconomic=1000;
            private float priceMaterialEconomic=1000;
            private float priceCashHouse=1000;
            private float priceMaterialHouse=1000;
            private float priceCashFabric=1000;
            private float priceMaterialFabric=1000;
        #endregion
    #endregion
    public GameObject AlertBox;
    public TMP_Text AlertTMPtext;

    // Update is called once per frame
    void Update()
    {
        //MouseScript
        Cash = Player.GetComponent<PlayerScript>().nowCash;
        Material = Player.GetComponent<PlayerScript>().nowMaterial;
        Place = Camera.GetComponent<MouseScript>().Place;
        if(Cash-priceCashEconomic>=0 || Material-priceMaterialEconomic>=0){
            imgEconmic.SetActive(false);
        } else {
            imgEconmic.SetActive(true);
        }

        if(Cash-priceCashHouse>=0  || Material-priceMaterialHouse>=0){
            imgHouse.SetActive(false);
        } else {
            imgHouse.SetActive(true);
        }

        if(Cash-priceCashFabric>=0  || Material-priceMaterialFabric>=0){
            imgFabric.SetActive(false);
        } else {
            imgFabric.SetActive(true);
        }
    }
    //Place.collider.GetComponent<Place_script>()
    private bool canBuyPlace(List<GameObject> List, string name, string[] coord){
        foreach (GameObject item in List)
        {
            if(item.transform.childCount==2){
                    if(item.transform.GetComponent<Place_script>().namethis == name){
                        if(item.transform.GetComponent<Place_script>().GetCoord() != coord)
                            return false;
                    }
                }

        }
        return true;
    }

    private IEnumerator AlertError(string ErrorText){
        AlertBox.SetActive(true);
        AlertTMPtext.text = ErrorText;
        yield return new WaitForSeconds(2);
        AlertBox.SetActive(false);
        
    }
    //Alert: You cannot build a building if there is a building of the same type within 2 cells of it
    public void BuyShop(){
        if(Place.collider){
            List<GameObject> Pcobjlst = new List<GameObject>(Place.collider.GetComponent<Place_script>().obj_list);
            if(canBuyPlace(Pcobjlst, "Shop",Place.collider.GetComponent<Place_script>().GetCoord())){
                if(Cash-priceCashEconomic>=0 && Material-priceMaterialEconomic>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - priceCashEconomic;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - priceMaterialEconomic;
                    Instantiate(Shop, Place.collider.transform.position+new Vector3(0,-1.5f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "Shop";
                    Camera.GetComponent<MouseScript>().CloseMenu();
                }
            }
            else {
                //AlertError("Alert: You cannot build a building if there is a building of the same type within 2 cells of it");
            }
        }
    }
    public void BuyHouse(){
        if(Place.collider){
            List<GameObject> Pcobjlst = new List<GameObject>(Place.collider.GetComponent<Place_script>().obj_list);
            if(canBuyPlace(Pcobjlst, "House",Place.collider.GetComponent<Place_script>().GetCoord())){
                if(Cash-priceCashHouse>=0 && Material-priceMaterialHouse>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - priceCashHouse;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - priceMaterialHouse;
                    Instantiate(Home, Place.collider.transform.position+new Vector3(0,-1.5f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "House";
                    Camera.GetComponent<MouseScript>().CloseMenu();
                }
            }
        }
    }
    public void BuyFabric(){
        if(Place.collider){
            List<GameObject> Pcobjlst = new List<GameObject>(Place.collider.GetComponent<Place_script>().obj_list);
            if(canBuyPlace(Pcobjlst, "Fabric",Place.collider.GetComponent<Place_script>().GetCoord())){
                if(Cash-priceCashFabric>=0 && Material-priceMaterialFabric>=0){
                    Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash - priceCashFabric;
                    Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial - priceMaterialFabric;
                    Instantiate(Fabric, Place.collider.transform.position+new Vector3(0,-1.5f,0), Quaternion.identity, Place.collider.transform);
                    Place.collider.GetComponent<IInteractable>().Interact();
                    Place.collider.GetComponent<Place_script>().namethis = "Fabric";
                    Camera.GetComponent<MouseScript>().CloseMenu();
                }
            }
        }
    }
}