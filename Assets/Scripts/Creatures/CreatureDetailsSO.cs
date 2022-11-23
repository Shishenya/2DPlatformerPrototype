using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureDetails_", menuName = "Scriptable Objects/Creatures/Creature Details")]
public class CreatureDetailsSO : ScriptableObject
{
    [Space(10)]
    [Header("Prefabs")]
    public GameObject prefabCreature;

    [Space(10)]
    [Header("Health parameters")]
    public int maxAmountHealth = 5;
}
