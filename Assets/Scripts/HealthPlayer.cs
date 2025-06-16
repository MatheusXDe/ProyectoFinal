using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    private float health;
    private float healthMaxime = 100;
    private Image rellenoBarraVida;

    bool isded;
    AdressInactive dedPanel;
    void Start()
    {
        health = 50;
        rellenoBarraVida = GameObject.FindGameObjectWithTag("FillHealth").GetComponent<Image>();
    }
    private void Update()
    {
        if (health > healthMaxime)
        {
            health = healthMaxime;
        }

        rellenoBarraVida.fillAmount = health / healthMaxime;

        if (health <= 0 && !isded)
        {
            Death(dedPanel);
            isded = true;
        }
    }

    public void HealthChange(float Number)
    {
        health += Number;
    }

    void Death(AdressInactive b)
    {
        AdressInactive[] a = FindObjectsByType<AdressInactive>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].id == "go") b = a[i];
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        b.gameObject.SetActive(true);
    }
}
