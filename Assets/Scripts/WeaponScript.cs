using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Collider weaponCollider;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthEnemy health = other.GetComponentInChildren<HealthEnemy>();
            health.HealthEnemyChange(FindFirstObjectByType<PlayerInv>().inventory[0].attack.statValue*10);  // Llamar la función de muerte en el enemigo
        }
    }

}

