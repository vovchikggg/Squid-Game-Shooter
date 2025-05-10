using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject panelSettings;

    private void Start()
    {
        if (panelSettings)
            panelSettings.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("Play");
    }

    public void Back()
    {
        SceneManager.LoadScene("Game");
    }

    public void Settings()
    {
        if (panelSettings.activeSelf == false)
        {
            panelSettings.SetActive(true);
        }
        else
        {
            panelSettings.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    // private void Awake()
    // {
    //     Instance = this;
    //     gameOverUI.SetActive(false);
    // }
    //
    // public void GameOver()
    // {
    //     Camera.main.orthographicSize = 25f;
    //     Time.timeScale = 0f; // Останавливаем игру
    //     gameOverUI.SetActive(true);
    // }
}