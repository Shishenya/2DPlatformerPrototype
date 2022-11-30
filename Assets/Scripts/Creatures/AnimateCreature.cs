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
        // Регистрируем евенты
        StartCoroutine(EventsRegisterRoutine());
    }

    private void OnDisable()
    {
        _creature.idleEvent.OnIdle -= IdleEvent_OnIdle;

        _creature.moveEvent.OnMove -= MoveEvent_OnMove;

        _creature.jumpEvent.OnJump -= JumpEvent_OnJump;

        _creature.weaponAttackEvent.OnWeaponAttack -= WeaponAttackEvent_OnWeaponAttack;

        _creature.deathEvent.OnDeath -= DeathEvent_OnDeath;
    }


    /// <summary>
    /// Событие спокойствия существа
    /// </summary>
    private void IdleEvent_OnIdle()
    {
        SetIdleAnimation();
    }

    /// <summary>
    /// Событие ходьбы
    /// </summary>
    private void MoveEvent_OnMove(MoveEventArgs moveEventArgs)
    {
        SetMoveAnimation(moveEventArgs.aimDirection);
    }

    /// <summary>
    /// Событие прыжка
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
    /// Событие атаки
    /// </summary>
    private void WeaponAttackEvent_OnWeaponAttack(WeaponAttackEventArgs weaponAttackEventArgs)
    {
        SetAttackAnimation(weaponAttackEventArgs.aimDirection);
    }

    /// <summary>
    /// Очистка состояний куда смотрит существо
    /// </summary>
    private void ClearAim()
    {
        _creature.animator.SetBool(Settings.aimLeft, false);
        _creature.animator.SetBool(Settings.aimRight, false);
    }

    /// <summary>
    /// Очистка состояний движения игрока
    /// </summary>
    private void ClearMovement()
    {
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isAttack, false);
        _creature.animator.SetBool(Settings.isDeath, false);
    }

    /// <summary>
    /// Состояние существа - покой
    /// </summary>
    private void SetIdleAnimation()
    {
        ClearAim();

        _creature.animator.SetBool(Settings.isIdle, true);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isAttack, false);
        _creature.animator.SetBool(Settings.isDeath, false);
    }

    /// <summary>
    /// Установка анимации для движения
    /// </summary>
    private void SetMoveAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isWalk, true);
        _creature.animator.SetBool(Settings.isAttack, false);
        _creature.animator.SetBool(Settings.isDeath, false);

        ClearAim();

        if (aimDirection == AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }

    /// <summary>
    /// Установка анимации для прыжка
    /// </summary>
    private void SetJumpAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isJump, true);
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isAttack, false);
        _creature.animator.SetBool(Settings.isDeath, false);

        ClearAim();

        if (aimDirection == AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }

    /// <summary>
    /// Установка анимации атаки
    /// </summary>
    private void SetAttackAnimation(AimDirection aimDirection)
    {
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isAttack, true);
        _creature.animator.SetBool(Settings.isDeath, false);

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
    /// Смерть существа
    /// </summary>
    private void DeathEvent_OnDeath()
    {
        SetDeathAnimation();
    }

    /// <summary>
    /// Анимация смерти
    /// </summary>
    private void SetDeathAnimation()
    {
        _creature.animator.SetBool(Settings.isJump, false);
        _creature.animator.SetBool(Settings.isIdle, false);
        _creature.animator.SetBool(Settings.isWalk, false);
        _creature.animator.SetBool(Settings.isAttack, false);
        _creature.animator.SetBool(Settings.isDeath, true);
    }

    /// <summary>
    /// Регистрация ивентов
    /// </summary>
    private IEnumerator EventsRegisterRoutine()
    {
        yield return null;

        _creature.idleEvent.OnIdle += IdleEvent_OnIdle; // покой

        _creature.moveEvent.OnMove += MoveEvent_OnMove; // движение

        _creature.jumpEvent.OnJump += JumpEvent_OnJump; // прыжок

        _creature.weaponAttackEvent.OnWeaponAttack += WeaponAttackEvent_OnWeaponAttack;

        _creature.deathEvent.OnDeath += DeathEvent_OnDeath;

        yield return null;
    }


}
