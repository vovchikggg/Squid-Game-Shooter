using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;

    private Rigidbody2D rb;
    
    public WeaponOwner weaponOwner;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        if (rb)
            rb.linearVelocity = transform.right * speed;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (weaponOwner)
        {
            case WeaponOwner.Player:
            {
                if (collision is CapsuleCollider2D && collision.transform.TryGetComponent(out EnemyEntity enemyEntity))
                {
                    enemyEntity.TakeDamage(damage);
                    Destroy(gameObject);
                }
                break;
            }
            case WeaponOwner.Enemy:
            {
                if (collision.transform.TryGetComponent(out PlayerEntity playerEntity))
                {
                    playerEntity.TakeDamage(damage);
                    Destroy(gameObject);
                }
                break;
            }
        }
        
        if (collision.transform.TryGetComponent(out Chest chest))
        {
            chest.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}