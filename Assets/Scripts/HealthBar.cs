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
    [SerializeField] private float _durationChanged;

    private Coroutine _save;

    private void Start()
    {
        _textHealthValue.text = _health.Value.ToString();
        _slider.value = _health.Value;
    }

    private void OnEnable()
    {
        _health.Reached += StartChange;
    }

    private void OnDisable()
    {
        _health.Reached -= StartChange;
    }

    private void StartChange()
    {
        if (_save != null)
            StopCoroutine(_save);
        
        _save = StartCoroutine(Change());        
    }

    private IEnumerator Change()
    {
        float runningTime = 0f;
        float targetValue = _health.Value;
        float difference = Mathf.Abs(_slider.value - targetValue);

        _textHealthValue.text = _health.Value.ToString();

        while (runningTime <= _durationChanged)
        {
            runningTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, (difference / _durationChanged) * Time.deltaTime);
            yield return null;
        }
    }
}