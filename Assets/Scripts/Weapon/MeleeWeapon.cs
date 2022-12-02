using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private Creatures _creature;
    private float _multiplicateVeloctityAfterUsingMeleeWeapon = 3f;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        _creature.weaponAttackEvent.OnMovementByAttack += WeaponAttackEvent_OnMovementByAttack;
    }

    private void OnDisable()
    {
        _creature.weaponAttackEvent.OnMovementByAttack -= WeaponAttackEvent_OnMovementByAttack;
    }

    /// <summary>
    /// Реакция на событие при атаке милишным оружием
    /// </summary>
    private void WeaponAttackEvent_OnMovementByAttack(WeaponAttackEventArgs weaponAttackEventArgs)
    {
        MovementMeleeAttack(weaponAttackEventArgs.movementX);
    }

    private void MovementMeleeAttack(float movementX)
    {
        Vector3 direction = new Vector3(movementX * _multiplicateVeloctityAfterUsingMeleeWeapon, _creature.rigidbody2D.velocity.y);
        _creature.rigidbody2D.velocity = direction;
    }

}
