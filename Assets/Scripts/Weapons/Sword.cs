using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Sword : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    
    public event EventHandler OnSwordSwing;

    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    
    public void Attack()
    {
        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
        {
            enemyEntity.TakeDamage(damageAmount);
        }
        
        if (collision.transform.TryGetComponent(out Chest chest))
        {
            chest.TakeDamage(damageAmount);
        }
        
        if (collision.transform.TryGetComponent(out PlayerEntity playerEntity))
        {
            playerEntity.TakeDamage(damageAmount);
        }
    }

    public void AttackColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    private void AttackColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }
}
