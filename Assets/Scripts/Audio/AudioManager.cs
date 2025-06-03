using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource takingDamageSound, deathSound, shotSound;
    
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    [SerializeField] private AudioSource[] musicAudio;
    [SerializeField] private AudioSource[] sfxAudio;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        musicVolumeSlider.value = Volume.Instance.musicVolume;
        sfxVolumeSlider.value = Volume.Instance.sfxVolume;
    }

    private void Update()
    {
        HandleSliders();
        HandleVolumes();
    }
    
    private void HandleVolumes()
    {
        foreach (var audio in musicAudio)
        {
            audio.volume = Volume.Instance.musicVolume;
        }
        foreach (var audio in sfxAudio)
        {
            audio.volume = Volume.Instance.sfxVolume;
        }
    }

    private void HandleSliders()
    {
        Volume.Instance.musicVolume = musicVolumeSlider.value;
        Volume.Instance.sfxVolume = sfxVolumeSlider.value;
    }
}