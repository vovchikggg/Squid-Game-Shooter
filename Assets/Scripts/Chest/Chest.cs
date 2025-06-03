using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Chest : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currentHealth;
    [SerializeField] private float shrinkFactor;
    [SerializeField] private Item[] availableItems;
    
    private void Start()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        transform.localScale *= 1 - shrinkFactor * damage;
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            var randomIndex = Mathf.FloorToInt(Random.value * availableItems.Length);
            var randomItem = availableItems[randomIndex];
            Instantiate(randomItem, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
