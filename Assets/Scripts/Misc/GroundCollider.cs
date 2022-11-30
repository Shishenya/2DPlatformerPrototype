using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Creatures>()!=null)
        {
            Creatures creature = collision.gameObject.GetComponent<Creatures>();
            if (creature.isJump)
            {
                creature.isJump = false;
            } else
            {
                creature.isGround = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Creatures>() != null)
        {
            Creatures creature = collision.gameObject.GetComponent<Creatures>();
                creature.isGround = true;
        }
    }
}
