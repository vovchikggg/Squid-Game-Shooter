using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}