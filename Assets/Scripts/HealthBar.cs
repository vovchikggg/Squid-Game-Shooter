using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetHealth(float health)
    {
        slider.gameObject.SetActive(health > 0);
        slider.value = health;
    }
}
