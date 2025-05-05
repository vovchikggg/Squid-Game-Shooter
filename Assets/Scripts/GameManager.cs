using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;
        gameOverUI.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Останавливаем игру
        gameOverUI.SetActive(true);
    }
}