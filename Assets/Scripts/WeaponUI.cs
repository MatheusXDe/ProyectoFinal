using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class RackField
{
    public bool hasChangedValue;
    public float ogValue, queuedValue;
    public int objFieldLevel;
    public int ogPrice, queuedPrice;
    public int priceScaleFactor;
}

public class WeaponUI : MonoBehaviour
{
    public RackField f_attack, f_attSpeed, f_endurance;

    public List<InvObj> playerInventory = new();
    List<Image> piIcons = new(); 

    public InvObj selectedObj;

    public void GetPlayerInventory()
    {
        playerInventory = FindAnyObjectByType<PlayerInv>().inventory;
        foreach (InvObj obj in playerInventory)
        {
            piIcons.Add(obj.objImage);
        }
    }
}
