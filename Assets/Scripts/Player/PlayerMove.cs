using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance { get; private set; }
    //[SerializeField] чтобы переменная отображ в Unity, но осталась private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f; //inputVector может быть очень маленьким, т.к float!
    private bool isRunning = false;

    private void Awake() // запускается до метода Start. Типо инициализация объектов
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update() // запускается каждый кадр

    private void FixedUpdate() // запускается через равные промежутки времени (сейчас 50 р/с), поэтому физика здесь               
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

        inputVector = inputVector.normalized; // приводит длину к ед, т.к по диагонали (1,1)

        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime)); //уменьшаем в fixedDeltaTime,
                                                                                          // но вызывааем n р/с поэтому он равен себе
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
