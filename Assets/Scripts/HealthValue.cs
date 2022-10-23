using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthValue : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _value;
    [SerializeField] private float _healWeight;
    [SerializeField] private float _damageWeight;
    [SerializeField] private UnityEvent _reached;

    public float Value => _value;   
    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnValidate()
    {
        _value = Mathf.Clamp(_value, _slider.minValue, _slider.maxValue);
    }       

    public void Heal()
    {
        Change(_healWeight);
    }

    public void MakeDamage()
    {
        Change(_damageWeight);
    }

    private void Change(float weight)
    {
        _value += weight;
        _value = Mathf.Clamp(_value, _slider.minValue, _slider.maxValue);
        _reached.Invoke();           
    }
}