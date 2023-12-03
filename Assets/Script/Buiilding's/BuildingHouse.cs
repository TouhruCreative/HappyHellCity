using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : MonoBehaviour, IBuilding
{
    public List<string> descUpgradeModiferOne { get; set; }
    public List<string> descUpgradeModiferTwo { get; set; }
    public float priceUpgradeModifOne {get;set;}
    public float priceUpgradeModifTwo {get;set;}

    public float ModifOne { get; set; }
    public float ModifTwo { get; set; }
    public string[] xy { get; set; }


    public GameObject Player;
    public float HappyNow;
    public float HappyMax = 100;

    public float People;

    public float polKoef;
    public float upgradeModifer;

    private List<GameObject> obj_list;
    public GameObject PlaceEffect;
    private GameObject pe;
    void Start() {

        ModifTwo=1.05f;
        priceUpgradeModifOne=5000.0f;
        priceUpgradeModifTwo=3000.0f;
        Player = GameObject.FindWithTag("Player");
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        HappyNow = HappyMax;
        upgradeModifer=5.0f;
        GetComponent<Animator>().SetBool("start", true);
        pe=Instantiate(PlaceEffect,transform.position,Quaternion.identity);
        Invoke("StartPlaceEffect",1f);
    }
    void Update()
    {
        xy = gameObject.GetComponentInParent<Place_script>().GetCoord();
        UpdateHappy();
        descUpgradeModiferOne= new List<string>{
            "Upgrade Happy",
            $"+{0.25f} happy bonus\n(current bonus: {ModifOne})\n\nprice: {priceUpgradeModifOne}"
        };
        descUpgradeModiferTwo= new List<string>{
            "Upgrade people",
            $"+{0.05f} poeple\n(current bonus: {ModifTwo})\n\nprice: {priceUpgradeModifTwo}"};
        gameObject.GetComponentInParent<Place_script>().modifString="Happy Count: "+HappyNow.ToString()+"\nPeople: "+People.ToString();
    }
    private void UpdateHappy(){
        polKoef=0;        
        foreach (GameObject item in obj_list)
        {
            if(item.transform.childCount==2){
                if(item.transform.GetChild(1).GetComponent<BuildingFabric>()){
                    polKoef+=item.transform.GetChild(1).GetComponent<BuildingFabric>().pollution_now/5;
                }
            }
        }
        HappyNow=HappyMax+ModifOne-polKoef;
        People=HappyNow*ModifTwo;
    }
    public void SellPlace(){
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().modifString = "";
        Destroy(this.gameObject);
    }
    public void UpgradeModifer(){
        ModifOne=ModifOne+1.0f;
    }
    public void UpgradeModiferTwo(){
        ModifTwo=ModifTwo+0.05f;
    }
    private void StartPlaceEffect(){
        Destroy(pe);
    }
}
