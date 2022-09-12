using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControllerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private ControllerHealthValue _controllerHealthValue;
    [SerializeField] private float _durationChanged;
        
    private float direction;    

    private void Start()
    {
        float _tempValue = _controllerHealthValue._valueHealth;
        _slider.value = _tempValue;
    }

    public void AddHealthSlider()
    {
        StartCoroutine(ChangedSlider(true));       
    }

    public void TakeHealthSlider()
    {
        StartCoroutine(ChangedSlider(false));        
    }

    private IEnumerator ChangedSlider(bool IsPositive)
    {
        direction = _controllerHealthValue.ChooseDirection(IsPositive);

        float runningTime = 0f;
        float targetValue = _slider.value + _controllerHealthValue.changeValue * direction;

        while (runningTime <= _durationChanged)
        {
            runningTime += Time.deltaTime;
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, (_controllerHealthValue.changeValue / _durationChanged) * Time.deltaTime);
            yield return null;
        }

        StopCoroutine(ChangedSlider(IsPositive));
    } 
}