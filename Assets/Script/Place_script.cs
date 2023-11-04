using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_script : MonoBehaviour, IInteractable
{
    public string namethis = "Free Place";
    public bool canBuy=true;
    public bool canModif=false;
    public string discription;
    public string modifString;
    
    public List<GameObject> obj_list;
    public string[] GetCoord(){
        string[] coord= new string[2];
        coord[0] = gameObject.name.Split(' ')[1];
        coord[1] = gameObject.name.Split(' ')[2];
        return coord;
    }
    public string GetDescription()
    {
        discription = "Name: "+namethis+"\n"+modifString;
        return discription;   
    }
    public void Interact(){
        canBuy = false;
        canModif =true;
    }
}
