using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myray : MonoBehaviour
{
    int distance = 10;
    public Camera cam;
    GameObject currentObject;
    bool canPickUp = false;
    public Transform fps; // first person controller
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E)){
            PickUp();
        }
    }
    void PickUp(){
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            if(hit.collider.tag=="Door"){
                if(!canPickUp){
                    currentObject=hit.transform.gameObject;

                    currentObject.GetComponent<Rigidbody>().isKinematic = true;
                    currentObject.GetComponent<Collider>().isTrigger = true;
                    currentObject.transform.parent = transform;
                    currentObject.transform.localPosition = new Vector3(0,0,2);
                    currentObject.transform.localEulerAngles = fps.transform.position;
                    canPickUp = true;
                }
                else{
                    currentObject=hit.transform.gameObject;

                    currentObject.GetComponent<Rigidbody>().isKinematic = false;
                    currentObject.GetComponent<Collider>().isTrigger = false;
                    currentObject.transform.parent = null;
                    canPickUp = false;
                }

            }
        }
    }
    void CreateRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            Debug.Log(hit.collider.name);
            if(hit.collider.tag == "Door"){
                Debug.Log("door");
            }
        }
    }
}
