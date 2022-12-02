using UnityEngine;

[CreateAssetMenu(fileName = "ContactDamageDetails_", menuName = "Scriptable Objects/Damage/Contact Damage Details")]
public class ContactDamageDetailsSO : ScriptableObject
{
    public int damage;
    public LayerMask layerMask;
}
