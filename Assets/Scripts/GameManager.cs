using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private bool menuIsStatic;
    private bool menuIsActive;

    private void Awake()
    {
        Instance = this;
        menuIsActive = menuIsStatic;
    }

    private void Start()
    {
        if (menuPanel)
            menuPanel.SetActive(menuIsStatic);
        if (settingsPanel)
            settingsPanel.SetActive(false);
    }

    private void Update()
    {
        if (!menuIsStatic && Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIsActive)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        menuIsActive = false;
        Time.timeScale = 1f;
        menuPanel.SetActive(menuIsActive);
    }

    public void Pause()
    {
        menuIsActive = true;
        Time.timeScale = 0f;
        menuPanel.SetActive(menuIsActive);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void LoadWinScreen()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadLossScreen()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Loss Screen");
    }

    public void Back()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Settings()
    {
        if (settingsPanel.activeSelf == false)
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }
        else
        {
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }
}