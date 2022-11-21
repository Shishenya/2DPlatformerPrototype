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
        StartCoroutine(EventsRegister());
    }

    private void OnDisable()
    {
        _creature.idleEvent.OnIdle -= IdleEvent_OnIdle;

        _creature.moveEvent.OnMove -= MoveEvent_OnMove;
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
    }

    /// <summary>
    /// ��������� �������� - �����
    /// </summary>
    private void SetIdleAnimation()
    {
        ClearAim();

        _creature.animator.SetBool(Settings.isIdle, true);
        _creature.animator.SetBool(Settings.isWalk, false);
    }

    private void SetMoveAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, true);

        ClearAim();

        if (aimDirection == AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }

    private IEnumerator EventsRegister ()
    {
        yield return new WaitForSeconds(0.1f);

        _creature.idleEvent.OnIdle += IdleEvent_OnIdle;

        _creature.moveEvent.OnMove += MoveEvent_OnMove;

        yield return null;
    }


}
