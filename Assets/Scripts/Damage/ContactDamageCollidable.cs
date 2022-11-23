using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamageCollidable : MonoBehaviour
{

    [SerializeField] private ContactDamageDetailsSO _contactDamageDetails;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            if (collision.gameObject.GetComponent<ImmunityAfterDamage>() != null)
            {
                if (!collision.gameObject.GetComponent<ImmunityAfterDamage>().IsImmunityAfterDamage)
                {
                    TakeContactDamage(collision);
                }
                else
                {
                    Debug.Log("Иммунитет к урону!");
                }
            }
            else
            {
                TakeContactDamage(collision);
            }



            #region Layer MASK!
            // переделать под layer mask
            #endregion

        }
    }

    private void TakeContactDamage(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " нанес контактный урон " + gameObject.name);
        collision.gameObject.GetComponent<Creatures>().changeHeatlhEvent.CallOnChangeHealthEvent(_contactDamageDetails.damage);
    }

}
