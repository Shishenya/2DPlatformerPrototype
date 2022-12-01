using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Creatures/Enemy Details")]
public class EnemyDetailsSO : ScriptableObject
{
    #region Move parameters
    [Space(10)]
    [Header("Move parameters")]
    #endregion
    public float changeMove = 5f;
    public bool isAlwaysFollowPlayer = false;

    #region Melee parameters
    [Space(10)]
    [Header("Melee parameters")]
    #endregion
    public float enemyMeleeRange = 2f;
    [Range(0f, 100f)]
    public float enemyChanceAttackMelee = 50f;

    #region Score parameters
    [Space(10)]
    [Header("Score parameters")]
    #endregion
    public int scorePoint = 10;
}
