using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : Death
{

    private float _secondAfterDestroy = 1.5f;

    public override void DeathCreature()
    {
        base.DeathCreature();
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(_secondAfterDestroy);
        Destroy(gameObject);
    }
}
