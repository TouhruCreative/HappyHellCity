using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public int speed = 5;
    public GameObject Camera_Object;
    void Start()
    {
        
        Camera_Object = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Camera_Object.transform.position += Camera_Object.transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S))
        {
            Camera_Object.transform.position -= Camera_Object.transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))
        {
            Camera_Object.transform.position += Camera_Object.transform.right * speed * Time.deltaTime;
            }
        if(Input.GetKey(KeyCode.A))
        {
            Camera_Object.transform.position -= Camera_Object.transform.right * speed * Time.deltaTime;
        }
    }
}
