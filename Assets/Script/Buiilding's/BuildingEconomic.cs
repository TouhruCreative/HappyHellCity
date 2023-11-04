using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEconomic : MonoBehaviour, IBuilding
{
    public List<string> descUpgradeModiferOne { get; set; }
    public List<string> descUpgradeModiferTwo { get; set; }
    public float priceUpgradeModifOne { get; set; }
    public float priceUpgradeModifTwo { get; set; }
    public float ModifOne { get; set; }
    public float ModifTwo { get; set; }
    public string[] xy { get; set; }

    public GameObject Player;
    public GameObject PauseObject;
    public float Profit;
    public float modifProfit;
    public float MinusModifProfit;

    private List<GameObject> obj_list;
    private bool canGiveCash=true;
    public string[] a;

    public string name1;
    void Start()
    {
        priceUpgradeModifOne=1000.0f;
        priceUpgradeModifTwo=1000.0f;
        ModifOne=1.0f;
        ModifTwo=15f;
        Player = GameObject.FindWithTag("Player");
        PauseObject=GameObject.FindWithTag("PauseObject");
        InvokeRepeating("Add_Money", 0, ModifTwo);
    }

    // Update is called once per frame
    void Update()
    {
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        gameObject.GetComponentInParent<Place_script>().modifString="Profit: "+Profit.ToString();
        xy = gameObject.GetComponentInParent<Place_script>().GetCoord();
        Update_Profit();
        descUpgradeModiferOne= new List<string>{
            "Upgrade profit",
            $"+{0.25f} bonus\n(current bonus: {ModifOne})\n\nprice: {priceUpgradeModifOne}"
        };
        descUpgradeModiferTwo= new List<string>{
            "Upgrade profit delay",
            $"-{0.05f} profit delay\n(current price delay: {ModifTwo})\n\nprice: {priceUpgradeModifTwo}"};
    }

    private void Add_Money() {
        if(canGiveCash==true && PauseObject.GetComponent<Pause>().itTime == true){
            Player.GetComponent<PlayerScript>().nowCash += Profit/2;
        }
    }
    private void Update_Profit(){
        modifProfit=0;
        MinusModifProfit=0;
        foreach (GameObject item in obj_list)
        {
            if(item.transform.childCount==2){
                if(item.transform.GetChild(1).GetComponent<BuildingHouse>()){
                        modifProfit = (item.transform.GetChild(1).GetComponent<BuildingHouse>().People * 3);
                    }

                if(item.transform.GetChild(1).GetComponent<BuildingFabric>()){
                        MinusModifProfit =item.transform.GetChild(1).GetComponent<BuildingFabric>().pollution_now / 2;
                    }
            }
        }
        Profit = (modifProfit - MinusModifProfit) * ModifOne;
    }

    public void SellPlace(){
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        
        Destroy(this.gameObject);
    }

    public void UpgradeModifer(){
        canGiveCash=false;
        ModifOne=ModifOne+0.25f;
        canGiveCash=true;
    }

    public void UpgradeModiferTwo(){
        CancelInvoke();
        canGiveCash=false;
        ModifTwo=ModifTwo-0.05f;
        InvokeRepeating("Add_Money", 0, ModifTwo);
        canGiveCash=true;
    }
    
}
