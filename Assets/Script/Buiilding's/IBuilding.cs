using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilding
{
    //Building's
    void SellPlace();
    string[] xy { get; set; }

    //Upgrade
    float priceUpgradeModifOne { get; set; }
    float priceUpgradeModifTwo { get; set; }
    void UpgradeModifer();
    void UpgradeModiferTwo();
    List<string> descUpgradeModiferOne { get; set; }
    List<string> descUpgradeModiferTwo { get; set; }
    float ModifOne { get; set; }
    float ModifTwo { get; set; }
}
