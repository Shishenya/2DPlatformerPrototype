using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creatures : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [Space(10)]
    #endregion
    [HideInInspector] public Animator animator;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public MoveEvent moveEvent;

    public CreatureDetailsSO creatureDetails;
    public MovementDetailsSO movementDetails;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        idleEvent = GetComponent<IdleEvent>();
        moveEvent = GetComponent<MoveEvent>();

    }

    /// <summary>
    /// Инициализация существа
    /// </summary>
    public virtual void InitCreatures()
    {

    }

}
