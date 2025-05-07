using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverUI;
    public int botCount = 22;

    private void Awake()
    {
        Instance = this;
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        Camera.main.orthographicSize = 25f;
        Time.timeScale = 0f; // Останавливаем игру
        gameOverUI.SetActive(true);
    }
}