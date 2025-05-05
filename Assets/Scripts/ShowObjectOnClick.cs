using UnityEngine;

public class ShowObjectOnClick : MonoBehaviour
{
    public KeyCode showKey = KeyCode.Space; // ������ ��� ���������
    public GameObject objectToShow; // ������, ������� ����� ��������

    void Start()
    {
        // �������� ������ ��� ������ (���� �� �� ����� �������)
        if (objectToShow != null)
            objectToShow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(showKey))
        {
            // ���������� ������
            if (objectToShow != null)
                objectToShow.SetActive(true);
        }
    }
}