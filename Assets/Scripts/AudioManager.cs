using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource takingDamageSound, deathSound;

    private void Awake()
    {
        Instance = this;
    }
}