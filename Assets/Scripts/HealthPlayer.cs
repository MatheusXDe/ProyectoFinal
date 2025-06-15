using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    private float health;
    private float healthMaxime = 100;
    private Image rellenoBarraVida;

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
    }

    public void HealthChange(float Number)
    {
        health += Number;
    }
}
