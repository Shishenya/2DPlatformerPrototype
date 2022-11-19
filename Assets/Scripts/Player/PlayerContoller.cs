using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Creatures _creatures;
    private float _testSpeed = 5f;

    private void Awake()
    {
        _creatures = GetComponent<Creatures>();
    }

    private void Update()
    {
        MoveInput(); // ждем нажатий 
    }

    /// <summary>
    /// ƒвижение игрока
    /// </summary>
    private void MoveInput()
    {
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

            _creatures.moveEvent.CallOnMoveEvent(aimDirection, _testSpeed);
        }

    }

}
