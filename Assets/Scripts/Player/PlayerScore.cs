using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    
    [SerializeField] private int botCount;
    [SerializeField] private Bar scoreBar;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        scoreBar.SetMaxValue(botCount);
    }
    
    public void HandleBotDeath()
    {
        scoreBar.IncreaseValue(1f);
        DetectWin();
    }

    private void DetectWin()
    {
        if (scoreBar.GetCurrentValue() >= botCount)
            GameManager.Instance.LoadWinScreen();
    }
}