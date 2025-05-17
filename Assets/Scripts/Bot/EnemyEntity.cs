using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Bar healthBar;
    
    private void Start()
    {
        healthBar.SetMaxValue(maxHealth);
        healthBar.SetCurrentValue(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        healthBar.DecreaseValue(damage);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (healthBar.GetCurrentValue() <= 0)
        {
            PlayerScore.Instance.HandleBotDeath();
            Destroy(gameObject);
        }
    }
}