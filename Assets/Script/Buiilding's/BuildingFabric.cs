using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFabric : MonoBehaviour
{
    public GameObject Player;
    public float efficiency_max =100;
    public float pollution_max  =30;

    public float efficiency_now;
    public float pollution_now;
    
    private List<GameObject> obj_list;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        efficiency_now=efficiency_max;
        pollution_now=pollution_max;
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        InvokeRepeating("Add_Material", 0, 30);
        InvokeRepeating("Update_pollution", 0, 30);
    }
    void Update()
    {
        gameObject.GetComponentInParent<Place_script>().modifString="Effeciency: "+efficiency_now.ToString()+"\nPollution: "+pollution_now.ToString();
        // foreach (GameObject item in obj_list)
        // {
        //     if(item.transform.childCount==2){
        //         if(item.transform.GetChild(1).GetComponent<BuildingHouse>()){
        //             item.transform.GetChild(1).GetComponent<BuildingHouse>().HappyNow=item.transform.GetChild(1).GetComponent<BuildingHouse>().HappyMax - pollution_now/5;
        //         }
        //     }
        // }
    }

    private void Update_pollution(){
        pollution_now = pollution_max;
        pollution_now = pollution_now + efficiency_now/5;
    }
    
    private void Add_Material() {
        Player.GetComponent<PlayerScript>().nowMaterial = Player.GetComponent<PlayerScript>().nowMaterial + efficiency_now;
    }
    public void SellPlace(){
        CancelInvoke("Add_Material");
        CancelInvoke("Update_pollution");
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().canBuy = true;
        this.gameObject.transform.parent.gameObject.GetComponent<Place_script>().namethis = "Free Place";
        
        Destroy(this.gameObject);
    }
}
