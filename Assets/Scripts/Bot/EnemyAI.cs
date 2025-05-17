using UnityEngine;

public class BotAI : MonoBehaviour
{
    [SerializeField] public Knife Knife;
    public float speed = 3f;  // �������� �������� ����
    public float stoppingDistance = 1f; // ����������, �� ������� ��� ��������������� ����� �������
    public Transform target; // ������ �� ������ ������ (���������� ������ � ��� ���� � ����������)
    public bool playerInSight;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        Knife.SetAttack(true);
        
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
            Debug.Log("Player In Sight!!!!!");
        }
    }

    // Вызывается, когда коллайдер (с триггером) выходит из триггерного коллайдера этого объекта
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }

    void FixedUpdate()
    {   
        if (target != null && playerInSight)
        {
            // ��������� ����������� � ������
            Vector2 direction = target.position - transform.position;
            var distance = direction.magnitude;
            direction.Normalize();  // ����������� ������ ��� ��������� �����������

            // ��������� � ������, ���� ���������� ������, ��� stoppingDistance
            if (distance > stoppingDistance)
            {
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}