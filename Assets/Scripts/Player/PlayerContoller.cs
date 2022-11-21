using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Creatures _creatures;
    private float _speed = 5f;

    private void Awake()
    {
        _creatures = GetComponent<Creatures>();
        _speed = _creatures.movementDetails.speed;
    }

    private void Update()
    {
        MoveInput(); // ���� ������� 
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    private void MoveInput()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        Vector2 direction = new Vector2(horizontalMovement, 0f);

        // ���� �������� ���, �� ��������� �����
        if (direction == Vector2.zero)
        {
            _creatures.idleEvent.CallOnIdleEvent();
        }
        // �������� ����
        else
        {
            AimDirection aimDirection;
            // ���������� �����������
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

}
