using UnityEngine;
using System;

public class PlayerKnife : MonoBehaviour
{
    public static PlayerKnife Instance { get; private set; }

    [SerializeField] public Knife Knife;

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
        Attack();

        //ActiveWeapon.Instance.GetActiveWeapon().SetAttack(true);

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

        if (Input.GetMouseButton(0)) // 0 - левая кнопка мыши
        {
            Knife.SetAttack(true);
        }
        else
        {
            Knife.SetAttack(false);
        }
    }

    public void Attack()
    {

    }

    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

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
