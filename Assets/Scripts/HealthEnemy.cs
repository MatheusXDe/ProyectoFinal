using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{

    public float health;
    private float healthMaxime = 100;
    private Image rellenoBarraVida;
    private Camera cam;
    private EnemyAI enemy;

    void Start()
    {
        health = healthMaxime;
        rellenoBarraVida = GameObject.FindGameObjectWithTag("FillEnemy").GetComponent<Image>();
        cam = Camera.main;
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
    }
    private void Update()
    {
        rellenoBarraVida.fillAmount = health / healthMaxime;
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        if (health == 0)
        {
              enemy.Morir();  // Llamar la función de muerte en el enemigo
            
        }
    }

    public void HealthEnemyChange(float Number)
    {
        health += Number;
    }
}
