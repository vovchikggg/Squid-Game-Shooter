using UnityEngine;
using System;

public class PlayerShotGun : MonoBehaviour
{
    public static PlayerShotGun Instance { get; private set; }

    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private PlayerInputActions playerInputActions;

    private float minMovingSpeed = 0.1f;
    private bool isRun = false;

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += Player_OnPlayerAttack; //пишем не в Awake, так как Awake рандомно вызывается
    }

    private void Player_OnPlayerAttack(object sender, System.EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();

        ActiveWeapon.Instance.GetActiveWeapon().SetAttackKnife(true);

    }

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void FixedUpdate()              
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));
                                                                                          // �� ��������� n �/� ������� �� ����� ����
        if (Math.Abs(inputVector.x) > minMovingSpeed || Math.Abs(inputVector.y) > minMovingSpeed)
            isRun = true;
        else
            isRun = false;
    }

    public Vector3 GetPlayerScreenPosition()
    {
        var playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    public bool IsRun()
    {
        return isRun;
    }
}
