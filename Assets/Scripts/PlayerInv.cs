using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public int money;
    public List<InvObj> inventory = new();

    private void Start()
    {
        UIManager.Call.UIMoneyUpdate(money);
    }
    public void UpdateMoneyOnShop(int newCoins, bool toAdd)
    {
        if (toAdd) money += newCoins; else money -= newCoins;
        UIManager.Call.UIMoneyUpdate(money);
    }

    public void UpdateMoneyGeneral(int newCoins)
    {
        money += newCoins;
        UIManager.Call.UIMoneyUpdate(money);
    }
}
