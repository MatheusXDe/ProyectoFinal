using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory Object", menuName = "Scriptable Objects/Inventory Object")]
public class SO_InvObj : ScriptableObject
{
    public ObjectClasses oc;
    public bool isTool, isWeapon;
    public float attack, defense, utility;
    public Image objImage;
}
