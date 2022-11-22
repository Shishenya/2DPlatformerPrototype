using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpEvent : MonoBehaviour
{
    public event Action<JumpEventArgs> OnJump;

    public void CallOnJumpEvent(float jumpForce, Vector2 direction, float speed)
    {
        OnJump?.Invoke(new JumpEventArgs() { jumpForce  = jumpForce, direction = direction, speed = speed });
    }
}

public class JumpEventArgs : EventArgs
{
    public float jumpForce;
    public Vector2 direction;
    public float speed;
}
