using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance { get; private set; }
    //[SerializeField] ����� ���������� ������� � Unity, �� �������� private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f; //inputVector ����� ���� ����� ���������, �.� float!
    private bool isRunning = false;

    private void Awake() // ����������� �� ������ Start. ���� ������������� ��������
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update() // ����������� ������ ����

    private void FixedUpdate() // ����������� ����� ������ ���������� ������� (������ 50 �/�), ������� ������ �����               
    {
        HandleMovement();
    }

    private void HandleMovement()
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
                                                                                          // �� ��������� n �/� ������� �� ����� ����
        if (Math.Abs(inputVector.x) > minMovingSpeed || Math.Abs(inputVector.y) > minMovingSpeed)
            isRunning = true;
        else
            isRunning = false;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

}
