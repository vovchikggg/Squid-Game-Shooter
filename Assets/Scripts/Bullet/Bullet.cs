using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
        if (rb)
            rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Столкновение с: " + other.gameObject.name + ", слой: " + other.gameObject.layer);
        
        var enemy = other.GetComponent<EnemyEntity>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        var chest = other.GetComponent<Chest>();
        if (chest)
        {
            chest.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        var player = other.GetComponent<PlayerEntity>();
        if (player)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
    }
}