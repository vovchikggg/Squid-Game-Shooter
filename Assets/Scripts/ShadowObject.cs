using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class ObjectSwitcher : MonoBehaviour
{
    [Header("Объекты для скрытия")]
    [SerializeField] private List<GameObject> objectsToHide;

    [Header("Объекты для показа")]
    [SerializeField] private List<GameObject> objectsToShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Проверяем нажатие клавиши 1
        {
            SwitchObjects();
        }
    }

    private void SwitchObjects()
    {

        // Скрываем все объекты в массиве objectsToHide
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // Показываем все объекты в массиве objectsToShow
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        for (var i = 0; i < objectsToHide.Count; i++)
        {
            var temp = objectsToHide[i];
            objectsToHide[i] = objectsToShow[i];
            objectsToShow[i] = temp;
        }

    }
}