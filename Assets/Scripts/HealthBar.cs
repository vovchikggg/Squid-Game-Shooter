using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private float currentHealth;

    public void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float health)
    {
        currentHealth = health;
        slider.maxValue = currentHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        slider.gameObject.SetActive(currentHealth > 0);
        slider.value = currentHealth;
    }
}
