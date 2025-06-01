using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private void Update()
    {
        var hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        
        if (hitInfo.collider)
        {
            if (hitInfo.collider.GetComponent<EnemyEntity>())
                hitInfo.collider.GetComponent<EnemyEntity>().TakeDamage(damage);
            
            if (hitInfo.collider.GetComponent<Chest>())
                hitInfo.collider.GetComponent<Chest>().TakeDamage(damage);
        
            if (hitInfo.collider.GetComponent<PlayerEntity>())
                hitInfo.collider.GetComponent<PlayerEntity>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
