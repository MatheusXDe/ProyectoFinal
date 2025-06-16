using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HealthEnemy : MonoBehaviour
{

    private float health;
    [SerializeField] float healthMaxime = 100;
    private Image rellenoBarraVida;
    private Camera cam;
    private EnemyAI enemy;

    void Start()
    {
        health = healthMaxime;
        rellenoBarraVida = transform.GetChild(1).gameObject.GetComponentInChildren<Image>();
        cam = Camera.main;
        enemy = GetComponentInParent<EnemyAI>();
    }
    private void Update()
    {
        rellenoBarraVida.fillAmount = health / healthMaxime;
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        if (health <= 0)
        {
            enemy.Morir();  // Llamar la función de muerte en el enemigo
        }
    }

    public void HealthEnemyChange(float Number)
    {
        health -= Number;
    }
}
