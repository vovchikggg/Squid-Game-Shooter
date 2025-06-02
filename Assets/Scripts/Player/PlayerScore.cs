using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    
    [SerializeField] private int moneyCount;
    [SerializeField] private Bar cashBar;
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        cashBar.SetMaxValue(moneyCount);
    }
    
    public void HandleMoney()
    {
        cashBar.IncreaseValue(1f);
        DetectWin();
    }

    private void DetectWin()
    {
        if (cashBar.GetCurrentValue() >= moneyCount)
            GameManager.Instance.LoadWinScreen();
    }
}