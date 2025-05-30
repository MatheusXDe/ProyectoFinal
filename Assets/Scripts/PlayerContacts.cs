using UnityEngine;

public class PlayerContacts : MonoBehaviour
{
    bool isEnter;

    private void Update()
    {
        Debug.Log("Into Blacksmith? " + isEnter);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Blacksmith")) isEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Blacksmith")) isEnter = false;
    }
}
