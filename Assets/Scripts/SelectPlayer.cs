using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject Knight;
    public GameObject Barbarian;
    public GameObject Mage;
    public GameObject Rogue;
    void Start()
    {

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
    void SelectKnight()
    {
        Knight.gameObject.SetActive(true);
        Barbarian.gameObject.SetActive(false);
        Mage.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(false);

    }
    void SelectBarbarian()
    {
        Knight.gameObject.SetActive(false);
        Barbarian.gameObject.SetActive(true);
        Mage.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(false);

    }
    void SelectMage()
    {
        Knight.gameObject.SetActive(false);
        Barbarian.gameObject.SetActive(false);
        Mage.gameObject.SetActive(true);
        Rogue.gameObject.SetActive(false);

    }
    void SelectRogue()
    {
        Knight.gameObject.SetActive(false);
        Barbarian.gameObject.SetActive(false);
        Mage.gameObject.SetActive(false);
        Rogue.gameObject.SetActive(true);

    }
}
