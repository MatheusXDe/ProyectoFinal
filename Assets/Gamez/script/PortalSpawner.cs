using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public Transform jugador;
    public GameObject portal;
    public GameObject enemigoPrefab;
    public int cantidadEnemigos = 3;
    public float distanciaActivacion = 5f;
    private bool Activa = false;

    /*void Update()
   {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            ActivarPortalYSpawn();
        }
    }*/

    void LateUpdate()
    {


        {
            float distancia = Vector3.Distance(transform.position, jugador.position);

            if (distancia <= distanciaActivacion && Activa ==false)
            {
                ActivarPortalYSpawn();
            }
        }
    }

    void ActivarPortalYSpawn()
    {
        portal.SetActive(true); // Activa la visibilidad del portal
        Invoke("SpawnEnemigos", 2f); // Genera los enemigos tras una pequeña espera
        Activa = true;
    }

    void SpawnEnemigos()
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            Vector3 posicionSpawn = portal.transform.position; // Los coloca en el portal
            GameObject enemigo = Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity);

            // Añadir una pequeña variación en la posición para evitar que se solapen
            enemigo.transform.position += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }

        Invoke("DestruirPortal", 3f); // Luego de spawn, destruye el portal
    }

    void DestruirPortal()
    {
        Destroy(portal);
    }
}

