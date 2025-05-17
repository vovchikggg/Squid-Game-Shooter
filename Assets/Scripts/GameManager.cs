using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private bool menuIsStatic;
    private bool menuIsActive;

    [Header("Settings")] [SerializeField] private int botCount;
    public int score;

    private void Awake()
    {
        Instance = this;
        menuIsActive = !menuIsStatic;
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

    public void UpdateScore()
    {
        if (textScore)
            textScore.text = $"Score: {score}";
        if (score >= botCount)
            LoadWinScreen();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadLossScreen()
    {
        SceneManager.LoadScene("Loss Screen");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Settings()
    {
        if (settingsPanel.activeSelf == false)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}