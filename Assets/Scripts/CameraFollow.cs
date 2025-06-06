using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador; // Referencia al objeto del jugador
    public Vector3 offset = new Vector3(0, 5, -10); // Posición relativa a mantener

    void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = jugador.position + offset; // Ajustar la posición
            transform.LookAt(jugador); // Mirar siempre al jugador
        }
    }
}

