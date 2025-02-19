using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI nowScore;

    private void OnEnable()
    {
        UIManager.OnScoreUpdated += UpdateNowScore;
        Debug.Log("GameUI OnScoreUpdated OnEnable");
        nowScore.text = "0";
    }

    private void OnDisable()
    {
        UIManager.OnScoreUpdated -= UpdateNowScore;
        Debug.Log("GameUI OnScoreUpdated OnDisable");
        Debug.Log("Leaving MiniGame Scene - totalScore: " + UIManager.Instance.totalScore);
    }

    private void UpdateNowScore(int now, int total, int best)
    {
        if (nowScore == null)
        {
            Debug.LogError("nowScore : NULL");
            return;
        }
        nowScore.text = now.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
