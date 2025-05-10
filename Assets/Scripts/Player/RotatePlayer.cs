using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 15f; // Скорость плавного поворота
    [SerializeField] private float deadZoneAngle = 5f; // Зона, в которой поворот не происходит

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
        // Вычисляем разницу углов с учетом кругового характера углов (например, разница между 350° и 10°)
        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        // Если разница в углах меньше deadZoneAngle - игнорируем маленькие изменения
        if (Mathf.Abs(angleDifference) > deadZoneAngle)
        {
            // Плавный поворот с использованием LerpAngle
            currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }
}