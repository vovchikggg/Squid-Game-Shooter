using UnityEngine;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject targetObject; // ������, ������� ����� ����������/����������
    public KeyCode toggleKey = KeyCode.Space; // ������� ��� ������������

    private bool isPlayerTag = true; // ���� ��� ������������ �������� ����

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            // ����������� ���������� �������
            targetObject.SetActive(!targetObject.activeSelf);

            // ������ ���
            if (isPlayerTag)
            {
                targetObject.tag = "Untagged";
                Debug.Log("��� ������ �� Untagged");
            }
            else
            {
                targetObject.tag = "Player";
                Debug.Log("��� ������ �� Player");
            }

            isPlayerTag = !isPlayerTag; // ����������� ����
        }
    }
}