using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    public static GameInput Instance { get; private set; }

    public event EventHandler OnPlayerAttack;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.Combat.Attack.started += PlayerAttack_started; //��������� ������� � Actions
    }

    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
        if (OnPlayerAttack != null) //���� �������, ������� ��������
            OnPlayerAttack.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVector() // ��� ������ � InputActions
    {
        var inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    public Vector3 GetMousePosition() //���������� ����� ������� � ����� GameInput
    {
        var mousePos = Input.mousePosition;
        return mousePos;
    }
}
