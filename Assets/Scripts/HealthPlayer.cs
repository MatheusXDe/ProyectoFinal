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
        health = 100f;
        //textMesh = GetComponent<TextMeshProUGUI>();
        rellenoBarraVida = GameObject.FindGameObjectWithTag("FillHealth").GetComponent<Image>();
    }
    private void Update()
    {
        //textMesh.text = health.ToString("0");
        rellenoBarraVida.fillAmount = health / healthMaxime;
    }

    public void HealthChange(float Number)
    {
        health += Number;
    }
}
