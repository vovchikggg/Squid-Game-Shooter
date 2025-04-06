using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance { get; private set; }
    //[SerializeField] чтобы переменная отображ в Unity, но осталась private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private PlayerInputActions playerInputActions;

    private float minMovingSpeed = 0.1f; //inputVector может быть очень маленьким, т.к float!
    private bool isRunning = false;

    private void Awake() // запускается до метода Start. Типо инициализация объектов
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    //private void Update() // запускается каждый кадр

    private void FixedUpdate() // запускается через равные промежутки времени (сейчас 50 р/с), поэтому физика здесь               
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        var inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized; // приводит длину к ед, т.к по диагонали (1,1)

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime)); //уменьшаем в fixedDeltaTime,
                                                                                          // но вызывааем n р/с поэтому он равен себе
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
