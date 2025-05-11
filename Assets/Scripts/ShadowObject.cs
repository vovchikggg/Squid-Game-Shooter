using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class ObjectSwitcher : MonoBehaviour
{
    [Header("������� ��� �������")]
    [SerializeField] private List<GameObject> objectsToHide;

    [Header("������� ��� ������")]
    [SerializeField] private List<GameObject> objectsToShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ��������� ������� ������� 1
        {
            SwitchObjects();
        }
    }

    private void SwitchObjects()
    {

        // �������� ��� ������� � ������� objectsToHide
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // ���������� ��� ������� � ������� objectsToShow
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