using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField] ����� ���������� ������� � Unity, �� �������� private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake() // ����������� �� ������ Start. ���� ������������� ��������
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update() // ����������� ������ ����

    private void FixedUpdate() // ����������� ����� ������ ���������� ������� (������ 50 �/�), ������� ������ �����               
    {
        var inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {

            inputVector.x = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1f;
        }

        inputVector = inputVector.normalized; // �������� ����� � ��, �.� �� ��������� (1,1)

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime)); //��������� � fixedDeltaTime,
    }                                                               // �� ��������� n �/� ������� �� ����� ����

}
