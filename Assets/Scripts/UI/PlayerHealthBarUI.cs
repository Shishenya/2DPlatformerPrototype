using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    /*[SerializeField]*/ private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        StartCoroutine(RegisterEventRoutine());
    }

    private void OnDisable()
    {
        GameManager.Instance.GetPlayer().GetComponent<Creatures>().changeHeatlhEvent.OnChangeHealth -= ChangeHeatlhEvent_OnChangeHealth;
    }

    private void Start()
    {
        SetStartHealthUI();
    }

    private void ChangeHeatlhEvent_OnChangeHealth(ChangeHeatlhEventArgs changeHeatlhEventArgs)
    {
        ChangeHealthUI(changeHeatlhEventArgs.amount);
    }

    private void ChangeHealthUI(int amount)
    {
        // _slider.value = GameManager.Instance.GetPlayer().GetComponent<Creatures>().health.CurrentAmountHealth;
        StartCoroutine(ChangeHealthUIRoutine());
    }

    private IEnumerator RegisterEventRoutine()
    {
        yield return null;
        GameManager.Instance.GetPlayer().GetComponent<Creatures>().changeHeatlhEvent.OnChangeHealth += ChangeHeatlhEvent_OnChangeHealth;
        yield return null;
    }

    /// <summary>
    /// Установка старотового значения здоровья
    /// </summary>
    private void SetStartHealthUI()
    {
        _slider.value = GameManager.Instance.GetPlayer().GetComponent<Creatures>().creatureDetails.maxAmountHealth;
    }

    private IEnumerator ChangeHealthUIRoutine()
    {
        yield return new WaitForFixedUpdate();
        _slider.value = GameManager.Instance.GetPlayer().GetComponent<Creatures>().health.CurrentAmountHealth;
    }



}
