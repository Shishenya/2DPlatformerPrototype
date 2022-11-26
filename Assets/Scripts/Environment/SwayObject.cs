using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayObject : MonoBehaviour, ISwayable
{
    private Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Колебание предмета
    /// </summary>

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Sway();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Sway();
    }

    /// <summary>
    /// Колебание предмета
    /// </summary>
    public void Sway()
    {
        StartCoroutine(SwayAnimatorRoutine());
    }

    /// <summary>
    /// Корутина колебания
    /// </summary>
    public IEnumerator SwayAnimatorRoutine()
    {
        _animator.SetBool(Settings.isSway, true);
        yield return new WaitForSeconds(1f);
        _animator.SetBool(Settings.isSway, false);
        yield return null;
    }
}
