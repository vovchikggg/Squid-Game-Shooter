using UnityEngine;

public class SlidesManager : MonoBehaviour
{
    public static SlidesManager Instance;

    [SerializeField] private GameObject[] StorySlides;
    [SerializeField] private GameObject TipsSlide;

    private void Awake()
    {
        Instance = this;
    }
}