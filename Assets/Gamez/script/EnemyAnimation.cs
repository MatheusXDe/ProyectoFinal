using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animador;

    void Start()
    {
        animador = GetComponent<Animator>();
    }

    public void SetPreparacion(bool estado)
    {
        animador.SetBool("Preparacion", estado);
    }

    public void SetCorrer(bool estado)
    {
        animador.SetBool("Correr", estado);
    }

    public void SetAtacar(bool estado)
    {
        animador.SetBool("Atacar", estado);
    }

    public void SetMuerte()
    {
        animador.SetBool("Muerte", true);
    }
}



