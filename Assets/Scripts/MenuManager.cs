using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class MenuManager : MonoBehaviour
{
    public GameObject menuPrincipal; // Canvas del Men�
    public GameObject historiaCanvas; // Canvas de la Historia

    public void OnPlayButtonClicked()
    {
        menuPrincipal.SetActive(false); // Oculta el men�
        historiaCanvas.SetActive(true); // Muestra la historia
    }
}