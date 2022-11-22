using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Creatures _creatures;
    private float _speed = 5f;
    private float _jumpForce;

    private void Awake()
    {
        _creatures = GetComponent<Creatures>();
        _speed = _creatures.movementDetails.speed;
        _jumpForce = _creatures.movementDetails.jumpForce;
    }

    private void Update()
    {

        MoveInput(); // движение 
        Jump(); // прыжок

    }

    /// <summary>
    /// ƒвижение игрока
    /// </summary>
    private void MoveInput()
    {

        if (_creatures.isJump) return;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontalMovement, 0f);

        // если движени€ нет, то сост€оние поко€
        if (direction == Vector2.zero)
        {
            _creatures.idleEvent.CallOnIdleEvent();
        }
        // движение есть
        else
        {
            AimDirection aimDirection;
            // ќпредел€ем направление
            if (horizontalMovement >= 0)
            {
                aimDirection = AimDirection.right;
            }
            else
            {
                aimDirection = AimDirection.left;
            }

            _creatures.moveEvent.CallOnMoveEvent(aimDirection, _speed);
        }

    }

    private void Jump()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontalMovement, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_creatures.isJump)
            {
                _jumpForce = 0f;
            }
            else
            {
                _jumpForce = _creatures.movementDetails.jumpForce;
            }
            _creatures.jumpEvent.CallOnJumpEvent(_jumpForce, direction, _speed);

        }

    }

}
