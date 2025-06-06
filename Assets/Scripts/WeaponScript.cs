using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Collider weaponCollider;

    void Start()
    {
        weaponCollider = GetComponent<Collider>();
        weaponCollider.enabled = false;  // Desactivar el collider por defecto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.Morir();  // Llamar la función de muerte en el enemigo
            }
        }
    }

    public void ActivateWeapon()
    {
        weaponCollider.enabled = true;
    }

    public void DeactivateWeapon()
    {
        weaponCollider.enabled = false;
    }
}

