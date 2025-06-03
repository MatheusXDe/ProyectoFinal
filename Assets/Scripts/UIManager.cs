using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Call;
    [SerializeField] GameObject bsmith;

    Canvas canvas;
    private void Awake()
    {
        UniqueUIM();

        canvas = GetComponent<Canvas>();

        AdressInactive ba = FindAnyObjectByType<AdressInactive>(FindObjectsInactive.Include);
        if (!(ba.id == "bs")) return; else bsmith = ba.gameObject;
    }

    public void GoToScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
        canvas.worldCamera = Camera.main;
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void BSmithOn(bool active)
    {
        bsmith.SetActive(active);
    }

    public void UniqueUIM()
    {
        if (Call == null && Call != this)
        {
            Call = this;
            DontDestroyOnLoad(Call.gameObject);
        }
        else Destroy(Call.gameObject);
    }
}
