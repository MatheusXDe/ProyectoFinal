using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject Knight;
    public GameObject Barbarian;
    public GameObject Mage;
    public GameObject Rogue;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SelectKnight();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SelectBarbarian();
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SelectMage();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SelectRogue();
        }

    }
    public void SelectKnight()
    {
        Barbarian.gameObject.SetActive(false);
        Mage.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(false);
        Knight.gameObject.SetActive(true);

    }
    public void SelectBarbarian()
    {
        Knight.gameObject.SetActive(false);
        Mage.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(false);
        Barbarian.gameObject.SetActive(true);

    }
    public void SelectMage()
    {
        Barbarian.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(false);
        Knight.gameObject.SetActive(false);
        Mage.gameObject.SetActive(true);

    }
    public void SelectRogue()
    {
        Barbarian.gameObject.SetActive(false);
        Mage.gameObject.SetActive(false);
        Knight.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(true);

    }
}
