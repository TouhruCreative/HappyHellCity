using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    List<GameObject> obj_list();
    GameObject Player();
    void SetDefualtValue();
    void SellPlace();
}
