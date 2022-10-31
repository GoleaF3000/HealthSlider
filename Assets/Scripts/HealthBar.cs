using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthValue _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _textHealthValue;
    [SerializeField] private float _speed;

    private Coroutine _save;

    private void Start()
    {
        _slider.minValue = _health.MinValue;
        _slider.maxValue = _health.MaxValue;
        _textHealthValue.text = _health.Value.ToString();
        _slider.value = _health.Value;
    }

    private void OnEnable()
    {
        _health.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnChanged;
    }

    private void OnChanged()
    {
        if (_save != null)
            StopCoroutine(_save);
        
        _save = StartCoroutine(Change());        
    }

    private IEnumerator Change()
    {       
        float targetValue = _health.Value;        

        _textHealthValue.text = _health.Value.ToString();
                
        while (_slider.value != targetValue)
        {            
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }
    }
}