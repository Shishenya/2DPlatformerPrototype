using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private MoveEvent _moveEvent;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _moveEvent = GetComponent<MoveEvent>();
    }

    private void OnEnable()
    {
        _moveEvent.OnMove += MoveEvent_OnMove;
    }

    private void OnDisable()
    {
        _moveEvent.OnMove -= MoveEvent_OnMove;
    }

    private void MoveEvent_OnMove(MoveEventArgs moveEventArgs)
    {
        Vector2 direction;
        if (moveEventArgs.aimDirection == AimDirection.left)
        {
            direction = new Vector2(-1f, 0f);
        }
        else
        {
            direction = new Vector2(1f, 0f);
        }

        _rigidbody2D.velocity = moveEventArgs.speed * direction;

    }

}
