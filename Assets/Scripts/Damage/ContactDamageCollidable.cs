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
                    //Debug.Log(collision.gameObject.name + " ����� ���������� ���� TRIGGER " + gameObject.name);
                }
                else
                {
                    //Debug.Log("��������� � �����! TRIGGER");
                }
            }
            else
            {
                TakeContactDamage(collision);
                //Debug.Log(collision.gameObject.name + " ����� ���������� ���� TRIGGER " + gameObject.name);
            }



            #region Layer MASK!
            // ���������� ��� layer mask
            #endregion

        }
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    private void TakeContactDamage(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name + " ����� ���������� ���� " + gameObject.name);
        collision.gameObject.GetComponent<Creatures>().changeHeatlhEvent.CallOnChangeHealthEvent(_contactDamageDetails.damage);
    }

}
