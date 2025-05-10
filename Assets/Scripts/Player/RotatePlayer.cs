using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 15f; // �������� �������� ��������
    [SerializeField] private float deadZoneAngle = 5f; // ����, � ������� ������� �� ����������

    private Camera mainCamera;
    private float currentAngle;
    private float targetAngle;

    private void Start()
    {
        mainCamera = Camera.main;
        currentAngle = transform.eulerAngles.z;
        targetAngle = currentAngle;
    }

    private void FixedUpdate()
    {
        UpdateTargetRotation();
        ApplySmoothRotation();
    }

    private void UpdateTargetRotation()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;
        targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void ApplySmoothRotation()
    {
        // ��������� ������� ����� � ������ ��������� ��������� ����� (��������, ������� ����� 350� � 10�)
        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        // ���� ������� � ����� ������ deadZoneAngle - ���������� ��������� ���������
        if (Mathf.Abs(angleDifference) > deadZoneAngle)
        {
            // ������� ������� � �������������� LerpAngle
            currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }
}