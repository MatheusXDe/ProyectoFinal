using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Call;
    [SerializeField] GameObject bsmith;
    [SerializeField] TMP_Text money;
    [SerializeField] AdressInactive[] ba;

    Canvas canvas;
    private void Awake()
    {
        UniqueUIM();

        canvas = GetComponent<Canvas>();

        ba = FindObjectsByType<AdressInactive>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        for (int i = 0; i < ba.Length; i++)
        {
            if (ba[i].id == "bs") bsmith = ba[i].gameObject;
        }
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

    public void UIMoneyUpdate(int m)
    {
        money.text = m.ToString();
    }
}
