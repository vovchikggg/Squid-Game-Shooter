using UnityEngine;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject targetObject; // Объект, который будет скрываться/появляться
    public KeyCode toggleKey = KeyCode.Space; // Клавиша для переключения

    private bool isPlayerTag = true; // Флаг для отслеживания текущего тега

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            // Переключаем активность объекта
            targetObject.SetActive(!targetObject.activeSelf);

            // Меняем тег
            if (isPlayerTag)
            {
                targetObject.tag = "Untagged";
                Debug.Log("Тег изменён на Untagged");
            }
            else
            {
                targetObject.tag = "Player";
                Debug.Log("Тег изменён на Player");
            }

            isPlayerTag = !isPlayerTag; // Инвертируем флаг
        }
    }
}