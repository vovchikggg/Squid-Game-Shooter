using UnityEngine;

public class Volume : MonoBehaviour
{
    public static Volume Instance;
    
    public float musicVolume;
    public float sfxVolume;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}