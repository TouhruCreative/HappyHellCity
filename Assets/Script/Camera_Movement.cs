using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public int speed = 30;
    public GameObject Camera_Object;
    public GameObject Camera;
    public float CameraAngle = 60.0F;
    void Start()
    {
        
        Camera_Object = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");

        if (mw < -0.1 && transform.position.y < 50f)
        {
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            Camera.transform.Rotate(1f, 0, 0);
        }
        if (mw > 0.1 && transform.position.y > 15f)
        {
            transform.position = transform.position - new Vector3(0, 0.5f, 0);
            Camera.transform.Rotate(-1f, 0, 0);
        }

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
