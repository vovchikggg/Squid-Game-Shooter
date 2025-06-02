using UnityEngine;

public class BotAI_shotgun : MonoBehaviour
{
    [SerializeField] public ShotGun Gun;
    public float speed = 3f;  // �������� �������� ����
    public float stoppingDistance = 1f; // ����������, �� ������� ��� ��������������� ����� �������
    public Transform target; // ������ �� ������ ������ (���������� ������ � ��� ���� � ����������)
    public bool playerInSight;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // ���� ���� �� ���������, ���������� ����� ������ �� ���� "Player"
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                Debug.LogError("��� ������� ������ � ����� 'Player'!");
                enabled = false; // ��������� ������, ����� �������� ������
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = true;
            Gun.SetFire(true);
            //Debug.Log("Player In Sight!!!!!");
        }
    }

    // Вызывается, когда коллайдер (с триггером) выходит из триггерного коллайдера этого объекта
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
            Gun.SetFire(false);
        }
    }

    void FixedUpdate()
    {   
        if (target != null && playerInSight)
        {
            // ��������� ����������� � ������
            Vector2 direction = transform.position - target.position ;
            var distance = direction.magnitude;
            direction.Normalize();  // ����������� ������ ��� ��������� �����������

            // ��������� � ������, ���� ���������� ������, ��� stoppingDistance
            if (distance > stoppingDistance)
            {
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
                var angle = AngleBetweenTwoVectors(Vector2.left, direction);
                Debug.Log(angle);
                rb.SetRotation(angle + 15);
            }
        }
    }
    
    // Вспомогательная функция для вычисления угла между двумя векторами
    public static float AngleBetweenTwoVectors(Vector2 from, Vector2 to)
    {
        // Используем Atan2 для получения угла в радианах
        float angle = Mathf.Atan2(to.y, to.x) - Mathf.Atan2(from.y, from.x);

        // Преобразуем радианы в градусы
        angle *= Mathf.Rad2Deg;

        // Возвращаем угол
        return angle;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}