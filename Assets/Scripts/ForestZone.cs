using UnityEngine;

public class ForestZone : MonoBehaviour
{
    public AudioSource ambientAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !ambientAudio.isPlaying)
        {
            ambientAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && ambientAudio.isPlaying)
        {
            ambientAudio.Stop();
        }
    }
}
