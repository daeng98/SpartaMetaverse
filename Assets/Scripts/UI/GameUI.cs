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

        nowScore.text = "0";
    }

    private void OnDisable()
    {
        UIManager.OnScoreUpdated -= UpdateNowScore;
    }

    private void UpdateNowScore(int now, int total)
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
