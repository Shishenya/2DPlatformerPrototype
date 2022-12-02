using System.Collections;
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
        // регистрируем эвенты
        StartCoroutine(RegisterEventsRoutine());
    }

    private void OnDisable()
    {
        _creature.changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
    }

    private void Update()
    {
        // если есть иммунтитет, уменьшаем таймер
        if (_isImmunityAfterDamage)
        {
            _timerImmunityAfterDamage -= Time.deltaTime;
        }

        // если время вышло, то сбрасываем таймер и убираем иммунитет
        if (_timerImmunityAfterDamage<0)
        {
            SetStartTimer();
            _isImmunityAfterDamage = false;
        }

    }

    /// <summary>
    /// Реакция на событие изменения здоровья
    /// </summary>
    private void ChangeHeatlhEvent_OnChangeHealth(ChangeHeatlhEventArgs changeHeatlhEventArgs)
    {
        SetImmunity(changeHeatlhEventArgs.amount);
    }

    /// <summary>
    /// Установка иммунитета
    /// </summary>
    private void SetImmunity(int amount)
    {
        // Если нанесен дамаг, то устанавливаем иимунитет
        if (amount>0)
        {
            _isImmunityAfterDamage = true;
            StartCoroutine(VisualImmunity());
        }
    }

    /// <summary>
    /// Визуализация того, что есть иммунитет
    /// </summary>
    private IEnumerator VisualImmunity()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColor = spriteRenderer.color;
        float normalAlpha = 1f;
        Color normalColor = new Color(currentColor.r, currentColor.g, currentColor.b, normalAlpha);
        Color blickColor = new Color(currentColor.r, currentColor.g, currentColor.b, normalAlpha / 2f);

        while (_isImmunityAfterDamage)
        {
            spriteRenderer.color = blickColor;
            yield return new WaitForSeconds(0.05f);
            spriteRenderer.color = normalColor;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(_immunityAfterDamageSecond);
        spriteRenderer.color = currentColor;

        yield return null;
    }

    /// <summary>
    /// Устанвока таймера на начало
    /// </summary>
    private void SetStartTimer()
    {
        _timerImmunityAfterDamage = _immunityAfterDamageSecond;
    }

    /// <summary>
    /// Корутина регистрации евентов
    /// </summary>
    private IEnumerator RegisterEventsRoutine()
    {
        yield return null;
        _creature.changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
        yield return null;
    }


}
