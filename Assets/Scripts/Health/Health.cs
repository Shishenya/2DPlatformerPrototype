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

        // ������������ ��������� �������� ��������
        SetStartAmountHealth();
    }

    /// <summary>
    /// ��������� ��������� �������� ��������
    /// </summary>
    private void SetStartAmountHealth()
    {
        _maxAmountHealth = _creature.creatureDetails.maxAmountHealth;
        _currentAmountHealth = _maxAmountHealth;
    }

    /// <summary>
    /// ��������� ������ �������� ��������, �������� ���������� ����� / ������
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
