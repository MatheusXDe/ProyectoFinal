using UnityEngine;

public class InstanciarPrefab : MonoBehaviour
{
    public GameObject prefab; // Prefab que se instanciará
    public EnemyAnimation enemigoAnim; // Referencia al script EnemyAnimation
    public Transform puntoInstancia; // Punto donde aparecerá el Prefab
    public float retardoDesactivacion = 0.5f; // Tiempo antes de destruir el objeto

    private bool estaAtacando;

    void Update()
    {
        bool ataqueActivo = enemigoAnim != null && enemigoAnim.GetComponent<Animator>().GetBool("Atacar");

        if (ataqueActivo && !estaAtacando)
        {
            estaAtacando = true;
            InstanciarEfecto();
        }
        else if (!ataqueActivo && estaAtacando)
        {
            estaAtacando = false;
        }
    }

    void InstanciarEfecto()
    {
        GameObject nuevoObjeto = Instantiate(prefab, puntoInstancia.position, puntoInstancia.rotation);
        Destroy(nuevoObjeto, retardoDesactivacion); // Destruye el objeto después de un tiempo
    }
}

