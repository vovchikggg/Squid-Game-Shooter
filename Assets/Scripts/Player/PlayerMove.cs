using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance { get; private set; }
    //[SerializeField] ����� ���������� ������� � Unity, �� �������� private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private PlayerInputActions playerInputActions;

    private float minMovingSpeed = 0.1f; //inputVector ����� ���� ����� ���������, �.� float!
    private bool isRunning = false;

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += Player_OnPlayerAttack; //пишем не в Awake, так как Awake рандомно вызывается
    }

    private void Player_OnPlayerAttack(object sender, System.EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }

    private void Awake() // ����������� �� ������ Start. ���� ������������� ��������
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    //private void Update() // ����������� ������ ����

    private void FixedUpdate() // ����������� ����� ������ ���������� ������� (������ 50 �/�), ������� ������ �����               
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized; // �������� ����� � ��, �.� �� ��������� (1,1)

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime)); //��������� � fixedDeltaTime,
                                                                                          // �� ��������� n �/� ������� �� ����� ����
        if (Math.Abs(inputVector.x) > minMovingSpeed || Math.Abs(inputVector.y) > minMovingSpeed)
            isRunning = true;
        else
            isRunning = false;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        var playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    public bool IsRunning()
    {
        return isRunning;
    }

}
