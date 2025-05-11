using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject panelSettings;
	[SerializeField] private TextMeshProUGUI textScore;

	[Header("Settings")]
    [SerializeField] private int botCount;
	public int score;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        if (panelSettings)
            panelSettings.SetActive(false);
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
}