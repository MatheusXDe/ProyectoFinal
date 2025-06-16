using UnityEngine;

public class PortalSoundOneShot : MonoBehaviour
{
    public AudioClip portalSound;
    public float volume = 1.0f;
    public float destroyDelay = 2f; // Tiempo antes de destruir el portal

    void Start()
    {
        // Reproducir el sonido al aparecer
        if (portalSound != null)
        {
            AudioSource.PlayClipAtPoint(portalSound, transform.position, 1.0f);
        }

        // Destruir el portal después del tiempo especificado
        Destroy(gameObject, destroyDelay);
    }
}
