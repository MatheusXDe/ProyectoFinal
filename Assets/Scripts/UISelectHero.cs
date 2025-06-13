using UnityEngine;

public class UISelectHero : MonoBehaviour
{
    public int heroIndex;
    public GameObject[] heroPanels;
    public void ChangeHero(bool add)
    {
        if (add) heroIndex++; else heroIndex--;

        if (heroIndex < 0) heroIndex = heroPanels.Length - 1;
        else if (heroIndex >= heroPanels.Length) heroIndex = 0;

        int i = 0;
        foreach (GameObject go in heroPanels)
        {
            if (i == heroIndex) go.SetActive(true);
            else go.SetActive(false);
            i++;
        }
    }
}
