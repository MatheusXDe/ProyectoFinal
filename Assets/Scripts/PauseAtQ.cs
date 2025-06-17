using UnityEngine;

public class PauseAtQ : MonoBehaviour
{
    [SerializeField] GameObject pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pause.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void UnPause()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
