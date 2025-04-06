using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //[SerializeField] чтобы переменная отображ в Unity, но осталась private
    [SerializeField] private float movingSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake() // запускается до метода Start. Типо инициализация объектов
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private void Update() // запускается каждый кадр

    private void FixedUpdate() // запускается через равные промежутки времени (сейчас 50 р/с), поэтому физика здесь               
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
    }                                                               // но вызывааем n р/с поэтому он равен себе

}
