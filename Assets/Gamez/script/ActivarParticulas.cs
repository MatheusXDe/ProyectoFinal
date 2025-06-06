using UnityEngine;

public class ActivarParticulas : MonoBehaviour
{
    public ParticleSystem particulas; // Asigna el sistema de partículas en el Inspector
    public EnemyAnimation enemigoAnim; // Referencia al script EnemyAnimation

    void Update()
    {
        // Verificamos si la animación de ataque está activa
        bool estaAtacando = enemigoAnim != null && enemigoAnim.GetComponent<Animator>().GetBool("Atacar");

        if (estaAtacando)
        {
            if (!particulas.isPlaying) particulas.Play();
        }
        else
        {
            if (particulas.isPlaying) particulas.Stop();
        }
    }
}
