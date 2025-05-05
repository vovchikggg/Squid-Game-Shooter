using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    public KeyCode showKey = KeyCode.Space; // Кнопка для появления
    public GameObject objectToShow; // Объект, который нужно показать

    void Start()
    {
        // Скрываем объект при старте (если он не скрыт вручную)
        if (objectToShow != null)
            objectToShow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(showKey))
        {
            // Показываем объект
            if (objectToShow != null)
                objectToShow.SetActive(true);
        }
    }
}