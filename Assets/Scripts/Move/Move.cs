using UnityEngine;

[RequireComponent(typeof(MoveEvent))]
[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
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
            direction = new Vector2(-moveEventArgs.speed, _rigidbody2D.velocity.y);
        }
        else
        {
            direction = new Vector2(moveEventArgs.speed, _rigidbody2D.velocity.y);
        }

        _rigidbody2D.velocity = direction;

    }

}
