using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFabric : MonoBehaviour, IBuilding
{
    
    public GameObject Player;
    public GameObject PauseObject;
    public float efficiency_max =100;
    public float pollution_max  =30;
    private bool canGive=true;

    public float efficiency_now;
    public float pollution_now;
    private List<GameObject> obj_list;

    public List<string> descUpgradeModiferOne { get; set; }
    public List<string> descUpgradeModiferTwo { get; set; }
    public float priceUpgradeModifOne {get;set;}
    public float priceUpgradeModifTwo {get;set;}
    public float ModifOne { get; set; }
    public float ModifTwo { get; set; }
    public string[] xy { get; set; }


    void Start()
    {
        ModifOne=1.0f;
        priceUpgradeModifOne=1000.0f;
        Player = GameObject.FindWithTag("Player");
        PauseObject=GameObject.FindWithTag("PauseObject");
        efficiency_now=efficiency_max;
        pollution_now=pollution_max;
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        ModifTwo=15.0f;
        InvokeRepeating("Add_Material", 0, ModifTwo);
        
    }
    void Update()
    {
        xy = gameObject.GetComponentInParent<Place_script>().GetCoord();
        gameObject.GetComponentInParent<Place_script>().modifString="Effeciency: "+efficiency_now.ToString()+"\nPollution: "+pollution_now.ToString();
        Update_pollution();
        descUpgradeModiferOne= new List<string>{
            "Upgrade efficiency",
            $"+{0.25f} bonus\n(current bonus: {ModifOne})\n\nprice: {priceUpgradeModifOne}"
        };
        descUpgradeModiferTwo= new List<string>{
            "Upgrade efficiency delay",
            $"-{0.05f} efficiency delay\n(current price delay: {ModifTwo})\n\nprice: {priceUpgradeModifTwo}"};
    }
    private void Update_pollution(){
        pollution_now = pollution_max;
        pollution_now = pollution_now + efficiency_now/5;
    }
    
    private void Add_Material() {
        if(canGive && PauseObject.GetComponent<Pause>().itTime == true){
            Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial + efficiency_now*ModifOne;
        }
    }
    public void SellPlace(){
        CancelInvoke("Add_Material");
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        
        Destroy(this.gameObject);
    }
    public void UpgradeModifer(){
        ModifOne=ModifOne+0.5f;
    }
    public void UpgradeModiferTwo(){
        canGive=false;
        CancelInvoke("Add_Material");
        ModifTwo=ModifTwo-0.05f;
        InvokeRepeating("Add_Material", 0, ModifTwo);
        canGive=true;
    }
}
