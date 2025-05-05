using UnityEngine;

public class BotAI : MonoBehaviour
{
    public float speed = 3f;  // Скорость движения бота
    public float stoppingDistance = 1f; // Расстояние, на котором бот останавливается перед игроком
    public Transform target; // Ссылка на объект игрока (перетащите игрока в это поле в инспекторе)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Если цель не назначена, попытаться найти игрока по тегу "Player"
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                Debug.LogError("Нет объекта игрока с тегом 'Player'!");
                enabled = false; // Отключаем скрипт, чтобы избежать ошибок
            }
        }
    }

    void FixedUpdate()
    {   
        if (target != null)
        {
            // Вычисляем направление к игроку
            Vector2 direction = target.position - transform.position;
            float distance = direction.magnitude;
            direction.Normalize();  // Нормализуем вектор для получения направления

            // Двигаемся к игроку, если расстояние больше, чем stoppingDistance
            if (distance > stoppingDistance)
            {
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            }
        }
    }

    // Рисуем Gizmo, чтобы видеть stoppingDistance в редакторе
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}