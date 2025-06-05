using UnityEngine;
using UnityEngine.AI;

public class EnemyAIRock : MonoBehaviour
{
    public Transform jugador; // Referencia al jugador
    private NavMeshAgent agente;
    private Animator animador;

    public float distanciaDeteccion = 10f;
    public float distanciaAtaque = 2f;
    private bool isWalking = false;
    private bool isAttacking = false;
    private bool isDead = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaDeteccion && distancia > distanciaAtaque) // Caminar hacia el jugador
        {
            isWalking = true;
            isAttacking = false;
            animador.SetBool("Caminar", true);
            animador.SetBool("Ataque", false);
            agente.SetDestination(jugador.position);
        }
        else if (distancia <= distanciaAtaque) // Atacar cuando esté cerca
        {
            isWalking = false;
            isAttacking = true;
            animador.SetBool("Caminar", false);
            animador.SetBool("Ataque", true);
            agente.ResetPath(); // Detener al enemigo para que ataque
        }
    }

    public void Morir()
    {
        isDead = true;
        isWalking = false;
        isAttacking = false;
        agente.ResetPath();
        animador.SetBool("Caminar", false);
        animador.SetBool("Ataque", false);
        animador.SetBool("Muerte", true);
    }
}

