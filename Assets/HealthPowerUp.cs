using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    [SerializeField] private Vector3 rotateChange;
    private HealthPlayer health;
    [SerializeField] private float pointsHealth;

    [Header("Audio")]
    [SerializeField] private AudioClip pickUpSound; // Arrástralo en el Inspector
    [SerializeField] private float volume = 1.0f;

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

            // Reproducir sonido en la posición del PowerUp
            if (pickUpSound != null)
            {
                AudioSource.PlayClipAtPoint(pickUpSound, transform.position, volume);
            }

            Destroy(gameObject);
        }
    }
}
