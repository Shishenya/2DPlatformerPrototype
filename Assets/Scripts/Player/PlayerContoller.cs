using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Creatures _creatures;
    private float _speed = 5f;
    private float _jumpForce;

    private float _horizontalMovement;
    private AimDirection _aimDirection;

    private void Awake()
    {
        _creatures = GetComponent<Creatures>();
        _speed = _creatures.movementDetails.speed;
        _jumpForce = _creatures.movementDetails.jumpForce;
    }

    private void Update()
    {

        // �������� �������� �� ����������
        _horizontalMovement = Input.GetAxisRaw("Horizontal");

        // �������� �����������
        if (_horizontalMovement >= 0)
        {
            _aimDirection = AimDirection.right;
        }
        else
        {
            _aimDirection = AimDirection.left;
        }

        MoveInput(); // �������� 

        Jump(); // ������

        Attack(); // �����

    }

    /// <summary>
    /// �������� ������
    /// </summary>
    private void MoveInput()
    {

        if (_creatures.isJump) return;

        if (_creatures.isAttack)
        {
            _creatures.weaponAttackEvent.CallMovementByAttack(0,AimDirection.left, _horizontalMovement);
            return;
        }

        Vector2 direction = new Vector2(_horizontalMovement, 0f);

        // ���� �������� ���, �� ��������� �����
        if (direction == Vector2.zero)
        {
            _creatures.idleEvent.CallOnIdleEvent();
        }
        // �������� ����
        else
        {
            _creatures.moveEvent.CallOnMoveEvent(_aimDirection, _speed);
        }

    }

    /// <summary>
    /// ������
    /// </summary>
    private void Jump()
    {

        Vector2 direction = new Vector2(_horizontalMovement, 0f);

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

    /// <summary>
    /// ����� ������
    /// </summary>
    private void Attack()
    {
        // ���� ������, �� �� �������
        if (_creatures.isJump) return;


        if (Input.GetMouseButtonDown(0))
        {
            // ������������� ���������
            _creatures.isAttack = true;
            _creatures.isIdle = false;

            // �������� ������� �����
            Vector3 positionClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            AimDirection direction;
            if (positionClick.x >= GameManager.Instance.GetPlayer().transform.position.x)
            {
                direction = AimDirection.right;
            }
            else
            {
                direction = AimDirection.left;
            }

            // ��������� �������� �����
            StartCoroutine(SetNormalStateAfterAttackRoutine());
            _creatures.weaponAttackEvent.CallWeaponAttackEvent(0, direction, _horizontalMovement);
        }
    }

    /// <summary>
    /// �������� �� ������� � ���������� ��������� ����� �����
    /// </summary>
    private IEnumerator SetNormalStateAfterAttackRoutine()
    {
        float durationSecond = 1f;
        yield return new WaitForSeconds(durationSecond);
        _creatures.isAttack = false;
        yield return null;
    }

}
