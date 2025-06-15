using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] private Vector3 rotateChange;
    private HealthPlayer health;
    [SerializeField] private float pointsHealth;

    void Start()
    {
        health = FindFirstObjectByType<HealthPlayer>();

    }
    void Update()
    {
        transform.Rotate(rotateChange);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health.HealthChange(pointsHealth);
            Destroy(gameObject);
        }
    }
}

