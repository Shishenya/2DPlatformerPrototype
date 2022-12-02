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
                }
                else
                {
                    //Debug.Log("Иммунитет к урону! TRIGGER");
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

    /// <summary>
    /// нанесения урона
    /// </summary>
    private void TakeContactDamage(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Creatures>() != null)
            collision.gameObject.GetComponent<Creatures>().changeHeatlhEvent.CallOnChangeHealthEvent(_contactDamageDetails.damage);
    }

}
