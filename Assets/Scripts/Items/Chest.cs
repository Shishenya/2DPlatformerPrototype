using UnityEngine;

public class Chest : MonoBehaviour, IUseable
{

    private Animator _animator;
    private bool _isOpen = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UseItem()
    {
        if (!_isOpen)
            OpenChest();
    }

    private void OpenChest()
    {
        _isOpen = true;
        _animator.SetBool(Settings.isUse, true);
    }
}
