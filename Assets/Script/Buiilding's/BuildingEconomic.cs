using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEconomic : MonoBehaviour
{
    public GameObject Player;
    public float Profit;
    public float modifProfit;
    public float MinusModifProfit;
    public float upgradeModifer=1f;

    private List<GameObject> obj_list;
    private bool canGiveCash=true;

    public float ModifDelay=30;
    void Start()
    {
        upgradeModifer=1f;
        Player = GameObject.FindWithTag("Player");
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        InvokeRepeating("Add_Money", 0, ModifDelay);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInParent<Place_script>().modifString="Profit: "+Profit.ToString()+"\n"+upgradeModifer.ToString();
        Update_Profit();
    }

    private void Add_Money() {
        if(canGiveCash==true){
            Player.GetComponent<PlayerScript>().nowCash += Profit/2;//Player.GetComponent<PlayerScript>().nowCash
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
        Profit = (modifProfit - MinusModifProfit) * upgradeModifer;
    }
    private void cancelInvoke(){
        canGiveCash=false;
        CancelInvoke("Add_Money");
    }

    public void SellPlace(){
        cancelInvoke();
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        
        Destroy(this.gameObject);
    }

    public void UpgradeModifer(){
        upgradeModifer+=1f;
        cancelInvoke();
        InvokeRepeating("Add_Money", 0, ModifDelay);
        canGiveCash=true;
    }
    public string nameUpgradeModifer="Upgrade profit";
    public string descUpgradeModifer="Upgrade profit";
    public string descUpgradeModiferTime="Upgrade profit";
    public string nameUpgradeModiferTime="Upgrade time";

    public void UpgradeModiferTime(){
        cancelInvoke();
        InvokeRepeating("Add_Money", 0, ModifDelay);
        canGiveCash=true;
    }
}
