using UnityEngine;
using System;

public class WeaponAttackEvent : MonoBehaviour
{
    public event Action<WeaponAttackEventArgs> OnWeaponAttack;

    public void CallWeaponAttackEvent(int damage, AimDirection aimDirection)
    {
        OnWeaponAttack?.Invoke(new WeaponAttackEventArgs() { damage = damage, aimDirection = aimDirection } );
    }

}

public class WeaponAttackEventArgs: EventArgs
{
    public int damage;
    public AimDirection aimDirection;
}