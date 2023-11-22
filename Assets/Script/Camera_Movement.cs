using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public int speed = 30;
    private GameObject Camera_Object;
    public GameObject Camera;
    private GameObject PauseObject;
    public GameObject Earth;
    public float CameraAngle = 60.0F;

    private float xMax = 100f;
    private float xMin = 55f;
    private float yMax = 120f;
    private float yMin = 30f;

    void Start()
    {
        PauseObject=GameObject.FindWithTag("PauseObject");
        Camera_Object = (GameObject)this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float mw = Input.GetAxis("Mouse ScrollWheel");

        if (mw < -0.1 && transform.position.y < 50f && PauseObject.GetComponent<Pause>().itTime == true)
        {
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            Camera.transform.Rotate(1f, 0, 0);
        }
        if (mw > 0.1 && transform.position.y > 15f && PauseObject.GetComponent<Pause>().itTime == true)
        {
            transform.position = transform.position - new Vector3(0, 0.5f, 0);
            Camera.transform.Rotate(-1f, 0, 0);
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            speed=40;
        } else {
            speed=30;
        }

        if(Input.GetKey(KeyCode.W) && Camera_Object.transform.position.z <= yMax)
        {
            Camera_Object.transform.position += Camera_Object.transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S) && Camera_Object.transform.position.z >= yMin)
        {
            Camera_Object.transform.position -= Camera_Object.transform.forward * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) && Camera_Object.transform.position.x <= xMax)
        {
            Camera_Object.transform.position += Camera_Object.transform.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) && Camera_Object.transform.position.x >= xMin)
        {
            Camera_Object.transform.position -= Camera_Object.transform.right * speed * Time.deltaTime;
        }
        
        
    }
}
