using UnityEngine;

public class PlayerContacts : MonoBehaviour
{
    bool isEnter;

    private void Update()
    {
        UIManager.Call.BSmithOn(isEnter);
        Cursor.visible = isEnter;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blacksmith"))
        {
            isEnter = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blacksmith")) {
            isEnter = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
