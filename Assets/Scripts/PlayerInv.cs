using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    public int money;
    public List<InvObj> inventory = new();

    [SerializeField] Animator an;

    private void Start()
    {
        UIManager.Call.UIMoneyUpdate(money);
        inventory.Clear();
        GetInventory();
        an = GetComponent<Animator>();
    }
    public void UpdateMoneyOnShop(int newCoins, bool toAdd)
    {
        if (toAdd) money += newCoins; else money -= newCoins;
        UIManager.Call.UIMoneyUpdate(money);
    }

    private void Update()
    {
        an.SetFloat("AttackSpeed", inventory[0].attackSpeed.statValue);
    }

    public void UpdateMoneyGeneral(int newCoins)
    {
        money += newCoins;
        UIManager.Call.UIMoneyUpdate(money);
    }

    void GetInventory()
    {
        foreach (InvObj item in GetComponentsInChildren<InvObj>())
        {
            inventory.Add(item);
        }
    }
}
