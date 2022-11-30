using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreature : Creatures
{
    public EnemyDetailsSO enemyDetailsSO;

    #region
    [Header("Attack parameters")]
    [Space(10)]
    #endregion
    public float newAttackSecond = 3f;
    private float timerAttackSecond;

    protected override void Awake()
    {
        base.Awake();

        SetTimerAttack();
    }

    private void Update()
    {

        if (isDeath) return;

        if (!isAttack)
        {
            timerAttackSecond -= Time.deltaTime;

            if (timerAttackSecond < 0)
            {
                EnemyAttack();
                SetTimerAttack();
            }
        }        
    }

    private void EnemyAttack()
    {
        StartCoroutine(EnemyAttackRouitine());
    }

    /// <summary>
    /// Установка таймера атаки
    /// </summary>
    private void SetTimerAttack()
    {
        timerAttackSecond = newAttackSecond;
    }

    /// <summary>
    /// Корутина атаки врага
    /// </summary>
    private IEnumerator EnemyAttackRouitine()
    {
        isAttack = true;
        // Debug.Log("Я враг " + name + ", я атакую");
        float _horizontalMovement = 0f;
        AimDirection direction = Utilites.LookAtPlayer(transform);
        weaponAttackEvent.CallWeaponAttackEvent(0, direction, _horizontalMovement);
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }
}
