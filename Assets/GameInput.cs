using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public static GameInput Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    public Vector2 GetMovementVector() // для работы с InputActions
    {
        var inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition() //переделать метод добавив в класс GameInput
    {
        var mousePos = Input.mousePosition;
        return mousePos;
    }
}
