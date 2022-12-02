using System.Collections;
using UnityEngine;

public class ChangeHealth : MonoBehaviour
{

    private Creatures _creature;
    private void Awake()
    {
        _creature = GetComponent<Creatures>();
    }

    private void OnEnable()
    {
        // ����������� �������
        StartCoroutine(RegisterEventsRoutine());
    }

    private void OnDisable()
    {
        _creature.changeHeatlhEvent.OnChangeHealth -= ChangeHeatlhEvent_OnChangeHealth;
    }

    /// <summary>
    /// ������ �� ������� ��������� ��������
    /// </summary>
    private void ChangeHeatlhEvent_OnChangeHealth(ChangeHeatlhEventArgs changeHeatlhEventArgs)
    {
        SetAmountHealth(changeHeatlhEventArgs.amount);
    }

    /// <summary>
    /// ���������� / ���������� ��������
    /// </summary>
    private void SetAmountHealth(int amount)
    {
        _creature.health.SetHealthAmount(amount);
    }

    private IEnumerator RegisterEventsRoutine()
    {
        yield return null;
        _creature.changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
        yield return null;
    }
}
