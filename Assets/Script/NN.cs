using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NN : MonoBehaviour
{
    public GameObject[] PlaceList;
    public GameObject Player;
    public float MaxHappy=0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlaceList = GameObject.FindGameObjectsWithTag("Building");
        MaxHappy=0;
        foreach(GameObject i in PlaceList){
            if(i.GetComponent<BuildingHouse>()==true){
                MaxHappy = MaxHappy + i.GetComponent<BuildingHouse>().HappyNow;
            }
        }
        Player.GetComponent<PlayerScript>().nowHappy = MaxHappy;
    }
    
}
