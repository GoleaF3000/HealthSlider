using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _value;

    public event UnityAction Changed;

    public float Value => _value;    

    private void OnValidate()
    {
        _value = Mathf.Clamp(_value, _slider.minValue, _slider.maxValue);
    }

    public void Heal(float weight)
    {
        Change(weight);
    }

    public void MakeDamage(float weight2)
    {
        Change(-weight2);
    }

    private void Change(float weight)
    {
        _value += weight;
        _value = Mathf.Clamp(_value, _slider.minValue, _slider.maxValue);
        Changed.Invoke();
    }
}