using UnityEngine;

public class PlayerContacts : MonoBehaviour
{
    bool isEnter;

    private void Update()
    {
        UIManager.Call.BSmithOn(isEnter);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blacksmith"))
        {
            isEnter = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blacksmith")) {
            isEnter = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
