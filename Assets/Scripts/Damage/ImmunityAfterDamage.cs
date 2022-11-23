using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunityAfterDamage : MonoBehaviour
{
    private Creatures _creature;
    private bool _isImmunityAfterDamage = false;
    private float _immunityAfterDamageSecond;
    private float _timerImmunityAfterDamage;

    public bool IsImmunityAfterDamage { get => _isImmunityAfterDamage; }

    private void Awake()
    {
        _creature = GetComponent<Creatures>();
        _immunityAfterDamageSecond = _creature.creatureDetails.ummunityAfterDamageSecond;
        SetStartTimer();
    }

    private void OnEnable()
    {
        // ������������ ������
        StartCoroutine(RegisterEventsRoutine());
    }

    private void OnDisable()
    {
        _creature.changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
    }

    private void Update()
    {
        // ���� ���� ����������, ��������� ������
        if (_isImmunityAfterDamage)
        {
            _timerImmunityAfterDamage -= Time.deltaTime;
        }

        // ���� ����� �����, �� ���������� ������ � ������� ���������
        if (_timerImmunityAfterDamage<0)
        {
            SetStartTimer();
            _isImmunityAfterDamage = false;
        }

    }

    /// <summary>
    /// ������� �� ������� ��������� ��������
    /// </summary>
    private void ChangeHeatlhEvent_OnChangeHealth(ChangeHeatlhEventArgs changeHeatlhEventArgs)
    {
        SetImmunity(changeHeatlhEventArgs.amount);
    }

    /// <summary>
    /// ��������� ����������
    /// </summary>
    private void SetImmunity(int amount)
    {
        // ���� ������� �����, �� ������������� ���������
        if (amount>0)
        {
            _isImmunityAfterDamage = true;
            StartCoroutine(VisualImmunity());
        }
    }

    /// <summary>
    /// ������������ ����, ��� ���� ���������
    /// </summary>
    private IEnumerator VisualImmunity()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColor = spriteRenderer.color;

        while(_isImmunityAfterDamage)
        {
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1f);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(_immunityAfterDamageSecond);
        spriteRenderer.color = currentColor;

        yield return null;
    }

    /// <summary>
    /// ��������� ������� �� ������
    /// </summary>
    private void SetStartTimer()
    {
        _timerImmunityAfterDamage = _immunityAfterDamageSecond;
    }

    /// <summary>
    /// �������� ����������� �������
    /// </summary>
    private IEnumerator RegisterEventsRoutine()
    {
        yield return null;
        _creature.changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
        yield return null;
    }


}
