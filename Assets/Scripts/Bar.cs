using System;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    private Slider slider;
    private float currentValue;

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
    }

    public float GetCurrentValue()
    {
        return currentValue;
    }
    
    public void SetCurrentValue(float value)
    {
        currentValue = value;
    }

    public void IncreaseValue(float addedValue)
    {
        currentValue += addedValue;
        HandleSlider();
    }
    
    public void DecreaseValue(float subtrahendValue)
    {
        currentValue -= subtrahendValue;
        HandleSlider();
    }

    private void HandleSlider()
    {
        slider.gameObject.SetActive(currentValue > 0);
        slider.value = currentValue;
    }
}
