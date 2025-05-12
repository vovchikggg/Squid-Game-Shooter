using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    private int _currentHealth;
    
    private void Start()
    {
        _currentHealth = maxHealth;
        healthBar.SetMaxHealth(_currentHealth);
        healthBar.SetHealth(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        healthBar.SetHealth(_currentHealth);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.score++;
            GameManager.Instance.UpdateScore();
        }
    }
}
