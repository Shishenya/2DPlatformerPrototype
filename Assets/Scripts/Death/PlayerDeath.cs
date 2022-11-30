using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : Death
{
    public override void DeathCreature()
    {
        base.DeathCreature();
        Debug.Log("персонаж погиб!");
    }
}
