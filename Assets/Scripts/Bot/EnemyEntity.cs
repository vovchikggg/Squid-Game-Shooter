using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    
    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        healthBar.TakeDamage(damage);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (healthBar.GetHealth() <= 0)
        {
            PlayerScore.Instance.HandleBotDeath();
            Destroy(gameObject);
        }
    }
}