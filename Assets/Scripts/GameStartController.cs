using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject historiaCanvas;

    public void StartGame()
    {
        menuCanvas.SetActive(false);
        historiaCanvas.SetActive(true);
    }
}
