using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Chest : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _currentHealth;
    [SerializeField] private float shrinkFactor;
    [SerializeField] private List<Icon> icons;
    
    private void Start()
    {
        _currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        transform.localScale *= shrinkFactor * damage;
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            foreach (var icon in icons)
            {
                Instantiate(icon.GetComponent<Spawn>().item, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
