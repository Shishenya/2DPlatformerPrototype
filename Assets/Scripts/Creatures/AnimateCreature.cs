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
        // событие спокойствия
        _creature.idleEvent.OnIdle += IdleEvent_OnIdle;

        // Событие ходьбы
        _creature.moveEvent.OnMove += MoveEvent_OnMove;

    }

    private void OnDisable()
    {
        _creature.idleEvent.OnIdle -= IdleEvent_OnIdle;

        _creature.moveEvent.OnMove -= MoveEvent_OnMove;
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
    }

    /// <summary>
    /// Состояние существа - покой
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

        if (aimDirection==AimDirection.left) _creature.animator.SetBool(Settings.aimLeft, true);
        if (aimDirection == AimDirection.right) _creature.animator.SetBool(Settings.aimRight, true);
    }
}
