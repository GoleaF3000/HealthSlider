using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text textHealthValue;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _valueHealth;
    [SerializeField] private float _durationChanged;

    private float changeValue = 10f;
    private float direction = -1f;
    private float minValue = 0f;
    private float maxValue = 100f;

    public void Start()
    {
        _slider.value = _valueHealth;
        textHealthValue.text = _valueHealth.ToString();
    }

    public void AddHealth()
    {
        StartCoroutine(ChangedSlider(true));
        ChangedHealth(true);
    }

    public void TakeHealth()
    {
        StartCoroutine(ChangedSlider(false));
        ChangedHealth(false);
    }

    private void WriteHealthValue(float healthValue)
    {
        string valueHealth = healthValue.ToString();
        textHealthValue.text = valueHealth;
    }

    private void ChangedHealth(bool IsPositive)
    {
        direction = ChooseDirection(IsPositive);

        if ((_valueHealth == minValue && IsPositive == true) || (_valueHealth == maxValue && IsPositive == false) || (_valueHealth > minValue && _valueHealth < maxValue))
        {
            _valueHealth += changeValue * direction;
            WriteHealthValue(_valueHealth);
        }
    }

    private IEnumerator ChangedSlider(bool IsPositive)
    {        
        direction = ChooseDirection(IsPositive);

        float runningTime = 0f;
        float targetValue = _slider.value + changeValue * direction;

        while (runningTime <= _durationChanged)
        {
            runningTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, (changeValue / _durationChanged) * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(ChangedSlider(IsPositive));
    }

    private float ChooseDirection(bool IsPositive)
    {
        if (IsPositive)
        {
            return 1f;
        }
        else
        {
            return -1f;
        }
    }
}