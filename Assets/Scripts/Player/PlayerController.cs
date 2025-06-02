using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    private PlayerInputActions playerInputActions;
    
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRun = false;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void Update()
    {
        HandleMovement();
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
    
    public bool IsRun()
    {
        return isRun;
    }
}