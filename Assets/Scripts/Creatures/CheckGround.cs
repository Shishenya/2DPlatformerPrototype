using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private Creatures _creature;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundCollider>()!=null)
        {
            _creature.isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GroundCollider>() != null)
        {
            _creature.isGround = false;
        }
    }
}
