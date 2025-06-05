using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Call;
    [SerializeField] GameObject bsmith;
    [SerializeField] TMP_Text money;

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

    public void RetrieveBSButton()
    {
        BSButton b = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<BSButton>();
        b.UpdateMoney();
    }

    public void UIMoneyUpdate(int m)
    {
        money.text = m.ToString();
    }
}
