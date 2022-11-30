using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    private Creatures _creature;

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        StartCoroutine(RegisterEventsRoutine());
    }

    private void OnDisable()
    {
        _creature.deathEvent.OnDeath -= DeathEvent_OnDeath;
    }

    /// <summary>
    /// Handle
    /// </summary>
    private void DeathEvent_OnDeath()
    {
        // Debug.Log(name + " death! ");
        DeathCreature();
    }

    /// <summary>
    /// Смерть существа
    /// </summary>
    public virtual void DeathCreature()
    {
        _creature.isDeath = true;       
        _creature.rigidbody2D.velocity = Vector2.zero;
    }


    /// <summary>
    /// Корутина регистрации евентов
    /// </summary>
    private IEnumerator RegisterEventsRoutine()
    {
        yield return null;
        _creature.deathEvent.OnDeath += DeathEvent_OnDeath;
        yield return null;
    }

}
