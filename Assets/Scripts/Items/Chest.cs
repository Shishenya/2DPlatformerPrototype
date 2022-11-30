using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IUseable
{
    public void UseItem()
    {
        Debug.Log("Открываю сунжук  " + name);
    }
}
