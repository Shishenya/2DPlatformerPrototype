using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Creatures/Enemy Details")]
public class EnemyDetailsSO : ScriptableObject
{
    [Space(10)]
    [Header("Move parameters")]
    public float changeMove = 5f;
    public bool isAlwaysFollowPlayer = false;

    [Space(10)]
    [Header("Melee parameters")]
    public float enemyMeleeRange = 2f;
    [Range(0f, 100f)]
    public float enemyChanceAttackMelee = 50f;
}
