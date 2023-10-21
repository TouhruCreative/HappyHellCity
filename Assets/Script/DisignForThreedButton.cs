using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisignForThreedButton : MonoBehaviour
{
    public GameObject ObjectC;
    public GameObject P;
    private float Cash;
    private float Material;
    void Update()
    {
        Cash = P.GetComponent<PlayerScript>().nowCash;
        Material = P.GetComponent<PlayerScript>().nowMaterial;
        if(Cash-1000>=0 && Material-1000>=0){
            if (Input.GetKeyDown(KeyCode.C)){
                ObjectC.GetComponent<Image>().color = new Color32(100,100,100,100);
            } else if (Input.GetKeyUp(KeyCode.C)){
                ObjectC.GetComponent<Image>().color = new Color32(255,255,225,100);
            }
        } else {
            ObjectC.GetComponent<Image>().color = new Color32(255,50,50,100);
        }
    }
}
