using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{

    private float health;
    private float healthMaxime = 100;
    private TextMeshProUGUI textMesh;
    private Image rellenoBarraVida;

    void Start()
    {
        health = healthMaxime;
        rellenoBarraVida = GameObject.FindGameObjectWithTag("FillHealth").GetComponent<Image>();
    }
    private void Update()
    {
        rellenoBarraVida.fillAmount = health / healthMaxime;
    }

    public void HealthChange(float Number)
    {
        health += Number;
    }
}
