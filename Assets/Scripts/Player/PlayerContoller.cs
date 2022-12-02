using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Creatures _creature;
    private float _speed = 5f;
    private float _jumpForce;

    private float _horizontalMovement;
    private AimDirection _aimDirection;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
        _speed = _creature.movementDetails.speed;
        _jumpForce = _creature.movementDetails.jumpForce;
    }

    private void Update()
    {

        if (_creature.isDeath)
        {
            _creature.rigidbody2D.velocity = Vector2.zero;
            return;
        }


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

        UseItem(); // ������������ �������

    }

    /// <summary>
    /// �������� ������
    /// </summary>
    private void MoveInput()
    {

        if (_creature.isJump) return;

        // ���� �������, �� �� ����� ���� � ���� ����� � ��������
        // if (!_creature.isGround) return;

        if (_creature.isAttack)
        {
            _creature.weaponAttackEvent.CallMovementByAttack(0, AimDirection.left, _horizontalMovement);
            return;
        }

        Vector2 direction = new Vector2(_horizontalMovement, 0f);

        // ���� �������� ���, �� ��������� �����
        if (direction == Vector2.zero)
        {
            _creature.idleEvent.CallOnIdleEvent();
        }
        // �������� ����
        else
        {
            _creature.moveEvent.CallOnMoveEvent(_aimDirection, _speed);
        }

    }

    /// <summary>
    /// ������
    /// </summary>
    private void Jump()
    {

        Vector2 direction = new Vector2(_horizontalMovement, 0f);

        if (Input.GetKeyDown(KeyCode.Space) && _creature.isGround && !_creature.isJump)
        {
            _jumpForce = _creature.movementDetails.jumpForce;
            _creature.jumpEvent.CallOnJumpEvent(_jumpForce, direction, _speed);
        }
    }

    /// <summary>
    /// ����� ������
    /// </summary>
    private void Attack()
    {
        // ���� ������, �� �� �������
        if (_creature.isJump) return;

        if (Input.GetMouseButtonDown(0))
        {
            // ������������� ���������
            _creature.isAttack = true;
            _creature.isIdle = false;

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
            _creature.weaponAttackEvent.CallWeaponAttackEvent(0, direction, _horizontalMovement);
        }
    }

    /// <summary>
    /// ������������� �������� ����� ����� ������
    /// </summary>
    private void UseItem()
    {
        if (_creature.isJump) return;
        if (_creature.isAttack) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(1f, 0f), Vector2.right, Settings.distanceUseable);
            // Debug.DrawRay(transform.position + new Vector3(1f, 0f), Vector2.right, Color.red, 3f);

            if (hitRight.collider == null) return;

            GameObject go = hitRight.collider.gameObject;

            if (go.GetComponent<IUseable>() != null)
            {
                IUseable iUseable = go.GetComponent<IUseable>();
                iUseable.UseItem();
            }
        }

    }

    /// <summary>
    /// �������� �� ������� � ���������� ��������� ����� �����
    /// </summary>
    private IEnumerator SetNormalStateAfterAttackRoutine()
    {
        float durationSecond = 1f;
        yield return new WaitForSeconds(durationSecond);
        _creature.isAttack = false;
        yield return null;
    }

}
