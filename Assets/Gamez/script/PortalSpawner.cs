using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    private Transform jugador;
    public GameObject portal;
    public GameObject enemigoPrefab;
    public int cantidadEnemigos = 3;
    public float distanciaActivacion = 5f;
    private bool Activa = false;

    void Start()
   {
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

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
        Vector3 posicionSpawn = portal.transform.position; // Usa la posición del portal
        posicionSpawn += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)); // Variación en X y Z

        // **Ajustar la posición en Y con Raycast**
        RaycastHit hit;
        if (Physics.Raycast(posicionSpawn + Vector3.up * 5f, Vector3.down, out hit, 10f))
        {
            posicionSpawn.y = hit.point.y; // Ajusta Y según el suelo detectado
        }
        else
        {
            posicionSpawn.y = portal.transform.position.y; // Como respaldo, usa la Y del portal
        }

        GameObject enemigo = Instantiate(enemigoPrefab, posicionSpawn, Quaternion.identity);
    }

    Invoke("DestruirPortal", 3f); // Luego de spawn, destruye el portal
}


    void DestruirPortal()
    {
        Destroy(portal);
    }
}

