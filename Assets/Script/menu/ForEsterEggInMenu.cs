using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEsterEggInMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(1))//if Click
        { 
            if (Physics.Raycast(ray, out hit,50f))//if Raycast
            {
                Debug.Log("1");
                if(hit.collider.tag == "EasterEgg")
                {
                    hit.collider.GetComponent<IEsterEgg>().EsterEggActive();
                }
            }//end(if Raycast)

        }//end(if click)
    }
}
