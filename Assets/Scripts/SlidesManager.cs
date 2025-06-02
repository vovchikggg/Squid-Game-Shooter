using UnityEngine;

public class SlidesManager : MonoBehaviour
{
    public static SlidesManager Instance;

    [SerializeField] private GameObject[] slides;
    private int index;

    private void Awake()
    {
        Instance = this;
    }

    public void NextSlide()
    {
        slides[index].SetActive(false);
        index++;
        slides[index].SetActive(true);
    }
}