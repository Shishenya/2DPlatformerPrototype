using UnityEngine;
using System;

public class ChangeHeatlhEvent : MonoBehaviour
{
    public event Action<ChangeHeatlhEventArgs> OnChangeHealth;

    public void CallOnChangeHealthEvent(int amount)
    {
        OnChangeHealth?.Invoke(new ChangeHeatlhEventArgs { amount = amount });
    }

}

public class ChangeHeatlhEventArgs: EventArgs
{
    public int amount;
}
