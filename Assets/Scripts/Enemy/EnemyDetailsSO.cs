using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDetails_", menuName = "Scriptable Objects/Creatures/Enemy Details")]
public class EnemyDetailsSO : ScriptableObject
{
    public float changeMove = 5f;
    public float enemyMeleeRange = 2f;
}
