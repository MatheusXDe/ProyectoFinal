using UnityEngine;

public class BSButton : MonoBehaviour
{
    [SerializeField] int newCoins;
    [SerializeField] bool add;

    public void UpdateMoney()
    {
        PlayerInv p = FindFirstObjectByType<PlayerInv>();
        p.UpdateMoneyOnShop(newCoins, add);
    }
}
