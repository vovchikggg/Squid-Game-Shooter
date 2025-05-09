using UnityEngine;

public class FPS : MonoBehaviour
{
    [SerializeField] private int fps;

    void OnValidate()
    {
        Application.targetFrameRate = fps;
    }
}
