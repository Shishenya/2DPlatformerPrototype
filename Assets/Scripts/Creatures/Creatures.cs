using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(MoveEvent))]
[RequireComponent(typeof(JumpEvent))]
[RequireComponent(typeof(ChangeHeatlhEvent))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(WeaponAttackEvent))]
[RequireComponent(typeof(DeathEvent))]
[DisallowMultipleComponent]
public abstract class Creatures : MonoBehaviour
{
    #region Components
    [Header("Components")]
    [Space(10)]
    #endregion
    [HideInInspector] public Animator animator;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
    [HideInInspector] public IdleEvent idleEvent;
    [HideInInspector] public MoveEvent moveEvent;
    [HideInInspector] public JumpEvent jumpEvent;
    [HideInInspector] public ChangeHeatlhEvent changeHeatlhEvent;
    [HideInInspector] public Health health;
    [HideInInspector] public WeaponAttackEvent weaponAttackEvent;
    [HideInInspector] public DeathEvent deathEvent;

    #region Weapon Creature
    [Space(10)]
    [Header("Weapon Creature")]
    #endregion
    public GameObject weaponCreature;


    #region Details Creature
    [Space(10)]
    [Header("Details Creature")]
    #endregion
    public CreatureDetailsSO creatureDetails;
    public MovementDetailsSO movementDetails;

    #region Referenves
    [Space(10)]
    [Header("References Objects")]
    #endregion
    public GameObject jumpPoint;

    // State
    /*[HideInInspector]*/
    public bool isJump = false;
    public bool isIdle = false;
    public bool isMove = false;
    public bool isAttack = false;
    public bool isGround = false;
    public bool isDeath = false;


    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        idleEvent = GetComponent<IdleEvent>();
        moveEvent = GetComponent<MoveEvent>();
        jumpEvent = GetComponent<JumpEvent>();
        changeHeatlhEvent = GetComponent<ChangeHeatlhEvent>();
        health = GetComponent<Health>();
        weaponAttackEvent = GetComponent<WeaponAttackEvent>();
        deathEvent = GetComponent<DeathEvent>();
    }

    private void Update()
    {
        CheckGroundUnderCreature();
    }

    private void CheckGroundUnderCreature()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(jumpPoint.transform.position, Vector2.down);
        // Debug.DrawRay(jumpPoint.transform.position, Vector2.down, Color.yellow, 3f);
        if (hitDown.distance>Settings.distanceRaycastJump)
        {
            isJump = true;
        }
    }

}
