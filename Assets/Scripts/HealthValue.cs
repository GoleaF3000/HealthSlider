using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthValue : MonoBehaviour
{    
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _value;

    public event UnityAction Changed;

    public float Value => _value;
    public float MinValue => _minValue;
    public float MaxValue => _maxValue;

    private void OnValidate()
    {
        _value = Mathf.Clamp(_value, _minValue, _maxValue);
    }

    public void Heal(float weight)
    {
        Change(weight);
    }

    public void MakeDamage(float weight)
    {
        Change(-weight);
    }

    private void Change(float weight)
    {
        _value += weight;
        _value = Mathf.Clamp(_value, _minValue, _maxValue);
        Changed?.Invoke();
    }
}