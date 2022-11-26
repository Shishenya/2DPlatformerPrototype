using UnityEngine;
using System;

public class WeaponAttackEvent : MonoBehaviour
{
    public event Action<WeaponAttackEventArgs> OnWeaponAttack;

    public event Action<WeaponAttackEventArgs> OnMovementByAttack;

    public void CallWeaponAttackEvent(int damage, AimDirection aimDirection, float movementX)
    {
        OnWeaponAttack?.Invoke(new WeaponAttackEventArgs() { damage = damage, aimDirection = aimDirection, movementX = movementX } );
    }

    public void CallMovementByAttack(int damage, AimDirection aimDirection, float movementX)
    {
        OnMovementByAttack?.Invoke(new WeaponAttackEventArgs() { damage = damage, aimDirection = aimDirection, movementX = movementX });
    }

}

public class WeaponAttackEventArgs: EventArgs
{
    public int damage;
    public AimDirection aimDirection;
    public float movementX;
}