using UnityEngine;

public class EnemyAnimationRock : MonoBehaviour
{
    private Animator animador;

    void Start()
    {
        animador = GetComponent<Animator>();
    }

    public void SetWalk(bool estado)
    {
        animador.SetBool("Caminar", estado);
    }

    public void SetAttack(bool estado)
    {
        animador.SetBool("Ataque", estado);
    }

    public void SetDead()
    {
        animador.SetBool("Muerte", true);
    }
}

