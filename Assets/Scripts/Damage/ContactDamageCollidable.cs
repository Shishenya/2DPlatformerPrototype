using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageCollidable : MonoBehaviour
{

    [SerializeField] private ContactDamageDetailsSO _contactDamageDetails;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            if (collision.gameObject.GetComponent<ImmunityAfterDamage>() != null)
            {
                if (!collision.gameObject.GetComponent<ImmunityAfterDamage>().IsImmunityAfterDamage)
                {
                    TakeContactDamage(collision);
                    Debug.Log(collision.gameObject.name + " нанес контактный урон TRIGGER " + gameObject.name);
                }
                else
                {
                    Debug.Log("Иммунитет к урону! TRIGGER");
                }
            }
            else
            {
                TakeContactDamage(collision);
                Debug.Log(collision.gameObject.name + " нанес контактный урон TRIGGER " + gameObject.name);
            }



            #region Layer MASK!
            // переделать под layer mask
            #endregion

        }
    }

    /// <summary>
    /// нанесения урона
    /// </summary>
    private void TakeContactDamage(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " нанес контактный урон " + gameObject.name);
        collision.gameObject.GetComponent<Creatures>().changeHeatlhEvent.CallOnChangeHealthEvent(_contactDamageDetails.damage);
    }

}
