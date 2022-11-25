using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private Creatures _creature;
    private float _multiplicateVeloctityAfterUsingMeleeWeapon = 0.2f;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        _creature.weaponAttackEvent.OnWeaponAttack += WeaponAttackEvent_OnWeaponAttack;
    }

    private void OnDisable()
    {
        _creature.weaponAttackEvent.OnWeaponAttack -= WeaponAttackEvent_OnWeaponAttack;
    }


    private void WeaponAttackEvent_OnWeaponAttack(WeaponAttackEventArgs weaponAttackEventArgs)
    {
        _creature.rigidbody2D.velocity = _creature.rigidbody2D.velocity * _multiplicateVeloctityAfterUsingMeleeWeapon;
    }

}
