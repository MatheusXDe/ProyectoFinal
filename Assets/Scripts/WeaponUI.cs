using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class RackField
{
    public bool hasChangedValue;
    public float ogValue, queuedValue;
    public int objFieldLevel;
    public int ogPrice, queuedPrice, corePrice;
    public string title;

    public TMP_Text t_title, t_coins, t_value, t_level;
    public Button purchase;

    public void InitValues(float ov, int olv)
    {
        ogValue = ov;
        objFieldLevel = olv;
        queuedValue = ogValue;
        queuedPrice = ogPrice;
        corePrice = ogPrice;

        purchase.interactable = hasChangedValue;
        UpdateUIValues();
    }
    public void EnqueueValues(bool add)
    {
        if (!add)
        {
            queuedValue -= ogValue;
            queuedPrice -= ogPrice;
            objFieldLevel--;
        }
        else
        {
            queuedValue += ogValue;
            queuedPrice += ogPrice;
            objFieldLevel++;
        }

        if (queuedValue > ogValue && queuedPrice > ogPrice) hasChangedValue = true;
        else hasChangedValue = false;

        purchase.interactable = hasChangedValue;

        UpdateUIValues();
    }
    public void MakeCheckout(int playermoney, float playerWV, int playerWL)
    {
        if (playermoney < queuedPrice) Debug.Log("Not enough money");
        else
        {
            playerWV = queuedValue;
            playerWL = objFieldLevel;

            ValuesAfterCO();
        }
    }
    public void ValuesAfterCO()
    {
        ogPrice = corePrice;
        ogValue = queuedValue;
        hasChangedValue = false;
        purchase.interactable = hasChangedValue;
        UpdateUIValues();
    }
    public void UpdateUIValues()
    {
        t_title.text = title;
        t_coins.text = queuedPrice.ToString();
        t_value.text = queuedValue.ToString();
        t_level.text = "Nv. "+objFieldLevel;
    }
}

public class WeaponUI : MonoBehaviour
{
    public RackField[] statFields;

    public PlayerInv player;
    public List<InvObj> playerInventory = new();
    List<Button> invButtons = new();

    public InvObj selectedObj;
    public Image im_selectedObj;

    private void OnEnable()
    {
        GetPlayerInventory();
    }

    private void OnDisable()
    {
        UnloadLists();
    }
    public void GetPlayerInventory()
    {
        player = FindAnyObjectByType<PlayerInv>();
        playerInventory = player.inventory;
        GameObject wr = GameObject.Find("Inventario Panel");

        foreach (Button b in wr.GetComponentsInChildren<Button>())
        {
            invButtons.Add(b);
        }

        for (int i = 0; i < playerInventory.Count; i++)
        {
            invButtons[i].image.sprite = playerInventory[i].objImage;
        }
    }

    public void GetCurrentObject(int order)
    {
        selectedObj = playerInventory[order];
        im_selectedObj.sprite = selectedObj.objImage;

        statFields[0].InitValues(selectedObj.attack.statValue, selectedObj.attack.statLevel);
        statFields[1].InitValues(selectedObj.attackSpeed.statValue, selectedObj.attackSpeed.statLevel);
        statFields[2].InitValues(selectedObj.endurance.statValue, selectedObj.endurance.statLevel);
    }

    public void EnqueueStat()
    {
        BSButton b = EventSystem.current.currentSelectedGameObject.GetComponent<BSButton>();

        statFields[b.rackPosition].EnqueueValues(b.toAdd);
    }
    public void Checkout(int pos)
    {
        switch (pos)
        {
            case 0:
                statFields[pos].MakeCheckout(player.money,selectedObj.attack.statValue, selectedObj.attack.statLevel);
                break;
            case 1:
                statFields[pos].MakeCheckout(player.money, selectedObj.attackSpeed.statValue, selectedObj.attackSpeed.statLevel);
                break;
            case 2:
                statFields[pos].MakeCheckout(player.money, selectedObj.endurance.statValue, selectedObj.endurance.statLevel);
                break;
            default:
                break;
        }
        player.UpdateMoneyOnShop(statFields[pos].queuedPrice, false);
        statFields[pos].ValuesAfterCO();
    }

    void UnloadLists()
    {
        playerInventory.Clear();
        invButtons.Clear();
    }
}
