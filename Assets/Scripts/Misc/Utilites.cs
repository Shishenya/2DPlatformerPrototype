using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilites
{

    /// <summary>
    /// ¬озвращает направление, в которое необходимо смотреть, чтобы видеть игрока
    /// </summary>
    public static AimDirection LookAtPlayer(Transform gameObjectTransform)
    {
        if (gameObjectTransform.position.x > GameManager.Instance.GetPlayer().transform.position.x)
        {
            return AimDirection.left;
        }
        else
        {
            return AimDirection.right;
        }
    }

}
