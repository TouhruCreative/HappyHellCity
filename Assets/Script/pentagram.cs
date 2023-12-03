using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pentagram : MonoBehaviour
{
    public GameObject MainCamera;
    public RaycastHit Place;
    void Start()
    {
        MainCamera= GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        Place=MainCamera.GetComponent<MouseScript>().Place;
        if(Place.collider && Place.collider.tag != "cantShow"){
            this.transform.position = Place.collider.transform.position;
        }
        else {
            this.transform.position = new Vector3(-10f,-10f,-10f);
        }
    }
}
