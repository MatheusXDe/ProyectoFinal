using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    HealthPlayer healthPlayer;
    public float damage;


    void Start()
    {
        healthPlayer = FindFirstObjectByType<HealthPlayer>();


    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthPlayer.HealthChange(-damage);
        }
    }
}

