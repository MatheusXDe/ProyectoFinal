using UnityEngine;
using TMPro;

public class HealthPlayer : MonoBehaviour
{

    private float health;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        health = 100f;
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textMesh.text = health.ToString("0");
    }

    public void HealthChange(float Number)
    {
        health += Number;
    }
}
