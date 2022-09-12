using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerHealthValue : MonoBehaviour
{
    [SerializeField] public float _valueHealth;
    [SerializeField] private TMP_Text _textHealthValue;

    public float changeValue { get; private set; } = 10f;
    private float direction = -1f;
    private float minValue = 0f;
    private float maxValue = 100f;

    private void Start()
    {
        _textHealthValue.text = _valueHealth.ToString();
    }

    public void AddHealthValue()
    {
        ChangedHealth(true);
    }

    public void TakeHealthValue()
    {
        ChangedHealth(false);
    }

    public float ChooseDirection(bool IsPositive)
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

    private void WriteHealthValue(float healthValue)
    {
        string valueHealth = healthValue.ToString();
        _textHealthValue.text = valueHealth;
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
}