using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Creatures _creature;
    private int _maxAmountHealth;
    private int _currentAmountHealth;

    public int CurrentAmountHealth { get => _currentAmountHealth; }

    private void Awake()
    {
        _creature = GetComponent<Creatures>();

        // Устанавлваем начальное значение здоровья
        SetStartAmountHealth();
    }

    /// <summary>
    /// Установка стартовых значений здоровья
    /// </summary>
    private void SetStartAmountHealth()
    {
        _maxAmountHealth = _creature.creatureDetails.maxAmountHealth;
        _currentAmountHealth = _maxAmountHealth;
    }

    /// <summary>
    /// Установка нового значения здоровья, согласно получениею урона / бонуса
    /// </summary>
    public void SetHealthAmount(int amount)
    {
        _currentAmountHealth -= amount;
        if (_currentAmountHealth<=0)
        {
            // Death
            _creature.deathEvent.CallOnDeathEvent();
        }
    }


}
