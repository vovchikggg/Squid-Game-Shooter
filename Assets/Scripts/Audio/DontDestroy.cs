using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        var obj = GameObject.FindGameObjectsWithTag("Audio");

        if (obj.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
