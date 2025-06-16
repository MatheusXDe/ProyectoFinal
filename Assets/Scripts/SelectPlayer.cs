using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject[] heroes;
    private GameObject cargando;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        int heroI = FindAnyObjectByType<UISelectHero>().heroIndex;

        int i = 0;
        foreach (GameObject hero in heroes)
        {
            if (i == heroI) hero.SetActive(true);
            else hero.SetActive(false);
            i++;
        }
        cargando = GameObject.FindGameObjectWithTag("Cargando");
        cargando.SetActive(false);
    }
}
