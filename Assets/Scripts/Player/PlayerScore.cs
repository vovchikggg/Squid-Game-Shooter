using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private int botCount;
    private int score;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public void HandleBotDeath()
    {
        score++;
        if (textScore)
            textScore.text = $"Score: {score}";
        if (score >= botCount)
            GameManager.Instance.LoadWinScreen();
    }
}