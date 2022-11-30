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
                if (CheckAttackMelee())
                {
                    EnemyAttack();
                }
                else
                {
                    SetTimerAttack();
                }
            }
        }
    }

    private void EnemyAttack()
    {
        StartCoroutine(EnemyAttackRouitine());
    }

    /// <summary>
    /// ��������� ������� �����
    /// </summary>
    private void SetTimerAttack()
    {
        timerAttackSecond = newAttackSecond;
    }

    /// <summary>
    /// �������� ����� �����
    /// </summary>
    private IEnumerator EnemyAttackRouitine()
    {
        isAttack = true;
        // Debug.Log("� ���� " + name + ", � ������");
        float _horizontalMovement = 0f;
        AimDirection direction = Utilites.LookAtPlayer(transform);
        weaponAttackEvent.CallWeaponAttackEvent(0, direction, _horizontalMovement);
        yield return new WaitForSeconds(1f);
        isAttack = false;
        SetTimerAttack();
    }

    /// <summary>
    /// ��������� ������� ��� ����� � ����
    /// </summary>
    private bool CheckAttackMelee()
    {
        if (Vector2.Distance(transform.position, GameManager.Instance.GetPlayer().transform.position) < enemyDetailsSO.enemyMeleeRange)
        {
            float rnd = Random.Range(0f, 100f);
            if (rnd < enemyDetailsSO.enemyChanceAttackMelee)
            {
                return true;
            }
        }
        return false;
    }

}
