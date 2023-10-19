using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : MonoBehaviour
{
    public GameObject Player;
    public float HappyNow;
    public float HappyMax = 100;

    public float People;

    public float polKoef;

    private List<GameObject> obj_list;
    void Start() {
        Player = GameObject.FindWithTag("Player");
        obj_list = gameObject.GetComponentInParent<Place_script>().obj_list;
        HappyNow = HappyMax;
    }
    void Update()
    {
        polKoef=0;        
        foreach (GameObject item in obj_list)
        {
            if(item.transform.childCount==2){
                if(item.transform.GetChild(1).GetComponent<BuildingFabric>()){
                    polKoef+=item.transform.GetChild(1).GetComponent<BuildingFabric>().pollution_now/5;
                }
            }
        }
        HappyNow=HappyMax-polKoef;
        People=HappyNow*2;
        gameObject.GetComponentInParent<Place_script>().modifString="Happy Count: "+HappyNow.ToString()+"\nPeople: "+People.ToString();
    }
    public void SellPlace(){
        Player.GetComponent<PlayerScript>().nowCash += 500;
        Destroy(this);
    }
}
