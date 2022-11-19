using UnityEngine;
using System;

public class MoveEvent : MonoBehaviour
{
    public event Action<MoveEventArgs> OnMove;

    public void CallOnMoveEvent(AimDirection aimDirection, float speed) {
        OnMove?.Invoke(new MoveEventArgs { aimDirection = aimDirection , speed = speed });
    }
}

public class MoveEventArgs: EventArgs
{
    public AimDirection aimDirection;
    public float speed;

}
