using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(MoveEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(ChangeHeatlhEvent))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(WeaponAttackEvent))]
[DisallowMultipleComponent]
public abstract class Creatures : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [Space(10)]
    #endregion
    [HideInInspector] public Animator animator;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public MoveEvent moveEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public ChangeHeatlhEvent changeHeatlhEvent;
    [HideInInspector] public Health health;
    [HideInInspector] public WeaponAttackEvent weaponAttackEvent;

    #region
    [Space(10)]
    [Header("Components Creature")]
    #endregion
    public GameObject weaponCreature;


    #region
    [Space(10)]
    [Header("Details Creature")]
    #endregion
    public CreatureDetailsSO creatureDetails;
    public MovementDetailsSO movementDetails;

    // State
    /*[HideInInspector]*/ public bool isJump = false;
    public bool isIdle = false;
    public bool isMove = false;
    public bool isAttack = false;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        idleEvent = GetComponent<IdleEvent>();
        moveEvent = GetComponent<MoveEvent>();
        jumpEvent = GetComponent<JumpEvent>();
        changeHeatlhEvent = GetComponent<ChangeHeatlhEvent>();
        health = GetComponent<Health>();
        weaponAttackEvent = GetComponent<WeaponAttackEvent>();
    }

    /// <summary>
    /// Инициализация существа
    /// </summary>
    public virtual void InitCreatures()
    {

    }

}
