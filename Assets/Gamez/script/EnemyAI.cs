using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private Transform jugador;
    private NavMeshAgent agente;
    private EnemyAnimation animacion;
    public float distanciaDeteccion = 10f;
    public float distanciaAtaque = 2f;
    private bool estaMuerto = false;
    private bool jugadorDetectado = false;
    private bool enPreparacion = false;
    

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animacion = GetComponent<EnemyAnimation>();
        animacion.SetPreparacion(false);
        animacion.SetCorrer(false);
        animacion.SetAtacar(false);
    }

    void Update()
    {
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (estaMuerto) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Fase de preparación antes de correr
        if (distancia < distanciaDeteccion && !jugadorDetectado)
        {
            jugadorDetectado = true;
            enPreparacion = true;
            animacion.SetPreparacion(true);
            StartCoroutine(EsperarYCorrer(3.5f)); // Pequeña pausa antes de correr
        }

        // Si la preparación ya terminó y el enemigo sigue detectando al jugador
        if (!enPreparacion && jugadorDetectado)
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

    IEnumerator EsperarYCorrer(float tiempo)
    {
        yield return new WaitForSeconds(tiempo); // Esperar antes de correr

        if (jugadorDetectado)
        {
            animacion.SetPreparacion(false); // Desactivar preparación
            enPreparacion = false; // Permitir que empiece a correr
            animacion.SetCorrer(true);
            agente.SetDestination(jugador.position);
        }
    }

    public void Morir()
    {
        estaMuerto = true;
        agente.ResetPath();
        animacion.SetMuerte();
    }
}











