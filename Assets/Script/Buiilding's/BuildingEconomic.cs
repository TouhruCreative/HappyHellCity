using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEconomic : MonoBehaviour
{
    public GameObject Player;
    public float Profit;
    public float modifProfit;
    public float MinusModifProfit;

    private List<GameObject> obj_list;

    public float ModifDelay=30;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        InvokeRepeating("Add_Money", 0, 30);
        InvokeRepeating("Update_Profit",0,30/2);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInParent<Place_script>().modifString="Profit: "+Profit.ToString();
    }

    private void Add_Money() {
        Player.GetComponent<PlayerScript>().nowCash = Player.GetComponent<PlayerScript>().nowCash + Profit;
    }
    private void Update_Profit(){
        modifProfit=0;
        MinusModifProfit=0;
        foreach (GameObject item in obj_list)
        {
            if(item.transform.childCount==2){
                if(item.transform.GetChild(1).GetComponent<BuildingHouse>()){
                        modifProfit = item.transform.GetChild(1).GetComponent<BuildingHouse>().People + (item.transform.GetChild(1).GetComponent<BuildingHouse>().People * 2);
                    }

                if(item.transform.GetChild(1).GetComponent<BuildingFabric>()){
                        MinusModifProfit =item.transform.GetChild(1).GetComponent<BuildingFabric>().pollution_now / 2;
                    }
            }
        }
        Profit = modifProfit - MinusModifProfit;
    }
    public void SellPlace(){
        CancelInvoke("Add_Money");
        CancelInvoke("Update_Profit");
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        
        Destroy(this.gameObject);
    }
}
