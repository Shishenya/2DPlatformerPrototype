using UnityEngine;
using System;

public class IdleEvent : MonoBehaviour
{
    public event Action OnIdle;

    public void CallOnIdleEvent()
    {
        OnIdle?.Invoke();
    }
}
