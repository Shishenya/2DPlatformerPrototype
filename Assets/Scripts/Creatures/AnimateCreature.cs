using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCreature : MonoBehaviour
{

    private Creatures _creature;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        // ������������ ������
        StartCoroutine(EventsRegisterRoutine());
    }

    private void OnDisable()
    {
        _creature.idleEvent.OnIdle -= IdleEvent_OnIdle;

        _creature.moveEvent.OnMove -= MoveEvent_OnMove;

        _creature.jumpEvent.OnJump -= JumpEvent_OnJump;

        _creature.weaponAttackEvent.OnWeaponAttack -= WeaponAttackEvent_OnWeaponAttack;
    }


    /// <summary>
    /// ������� ����������� ��������
    /// </summary>
    private void IdleEvent_OnIdle()
    {
        SetIdleAnimation();
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    private void MoveEvent_OnMove(MoveEventArgs moveEventArgs)
    {
        SetMoveAnimation(moveEventArgs.aimDirection);
    }

    /// <summary>
    /// ������� ������
    /// </summary>
    private void JumpEvent_OnJump(JumpEventArgs jumpEventArgs)
    {
        AimDirection aimDirection;
        if (jumpEventArgs.direction.x >= 0)
        {
            aimDirection = AimDirection.right;
        }
        else
        {
            aimDirection = AimDirection.left;
        }

        SetJumpAnimation(aimDirection);
    }

    /// <summary>
    /// ������� �����
    /// </summary>
    private void WeaponAttackEvent_OnWeaponAttack(WeaponAttackEventArgs weaponAttackEventArgs)
    {
        SetAttackAnimation(weaponAttackEventArgs.aimDirection);
    }

    /// <summary>
    /// ������� ��������� ���� ������� ��������
    /// </summary>
    private void ClearAim()
    {
        _creature.animator.SetBool(Settings.aimLeft, false);
        _creature.animator.SetBool(Settings.aimRight, false);
    }

    /// <summary>
    /// ������� ��������� �������� ������
    /// </summary>
    private void ClearMovement()
    {
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isAttack, false);
    }

    /// <summary>
    /// ��������� �������� - �����
    /// </summary>
    private void SetIdleAnimation()
    {
        ClearAim();

        _creature.animator.SetBool(Settings.isIdle, true);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isAttack, false);
    }

    /// <summary>
    /// ��������� �������� ��� ��������
    /// </summary>
    private void SetMoveAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isWalk, true);
        _creature.animator.SetBool(Settings.isAttack, false);

        ClearAim();

        if (aimDirection == AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }

    /// <summary>
    /// ��������� �������� ��� ������
    /// </summary>
    private void SetJumpAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isJump, true);
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isAttack, false);

        ClearAim();

        if (aimDirection == AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }

    /// <summary>
    /// ��������� �������� �����
    /// </summary>
    private void SetAttackAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isAttack, true);

        ClearAim();

        if (aimDirection == AimDirection.left) { 
            _creature.animator.SetBool(Settings.aimLeft, true);
        }
        if (aimDirection == AimDirection.right)
        {
            _creature.animator.SetBool(Settings.aimRight, true);
        }
    }

    /// <summary>
    /// ����������� �������
    /// </summary>
    private IEnumerator EventsRegisterRoutine()
    {
        yield return null;

        _creature.idleEvent.OnIdle += IdleEvent_OnIdle; // �����

        _creature.moveEvent.OnMove += MoveEvent_OnMove; // ��������

        _creature.jumpEvent.OnJump += JumpEvent_OnJump; // ������

        _creature.weaponAttackEvent.OnWeaponAttack += WeaponAttackEvent_OnWeaponAttack;

        yield return null;
    }


}
