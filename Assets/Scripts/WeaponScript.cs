using Unity.VisualScripting;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Collider weaponCollider;
    public float damage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HealthEnemy health = other.GetComponentInChildren<HealthEnemy>();
            health.HealthEnemyChange(damage);  // Llamar la función de muerte en el enemigo
            
        }
    }

}

