using UnityEngine;
using UnityEngine.AI;

public class EnemyAIFast : MonoBehaviour
{
    private Transform jugador;
    private NavMeshAgent agente;
    private EnemyAnimation animacion;
    public float distanciaDeteccion = 10f;
    public float distanciaAtaque = 2f;
    private bool estaMuerto = false;
    private bool jugadorDetectado = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animacion = GetComponent<EnemyAnimation>();
        animacion.SetCorrer(false);
        animacion.SetAtacar(false);
    }

    void Update()
    {
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (estaMuerto) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Detectar al jugador y empezar a correr inmediatamente
        if (distancia < distanciaDeteccion)
        {
            jugadorDetectado = true;
            animacion.SetCorrer(true);
            agente.SetDestination(jugador.position);
        }

        if (jugadorDetectado)
        {
            if (distancia > distanciaAtaque)
            {
                agente.SetDestination(jugador.position);
                animacion.SetCorrer(true);
                animacion.SetAtacar(false);
            }
            else
            {
                agente.ResetPath();
                agente.velocity = Vector3.zero;
                animacion.SetCorrer(false);
                animacion.SetAtacar(true);
            }
        }
    }

    public void Morir()
    {
        estaMuerto = true;
        agente.ResetPath();
        animacion.SetMuerte();
    }
}

