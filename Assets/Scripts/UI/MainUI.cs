using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] public TextMeshProUGUI totalScore;
    [SerializeField] public TextMeshProUGUI bestScore;

    private void OnEnable()
    {
        UIManager.OnScoreUpdated -= UpdateTotalScore;
        UIManager.OnScoreUpdated -= UpdateBestScore;
        Debug.Log("MainUI OnScoreUpdated OnDisable");
        UIManager.OnScoreUpdated += UpdateTotalScore;
        UIManager.OnScoreUpdated += UpdateBestScore;
        Debug.Log("MainUI OnScoreUpdated OnEnable");
    }

    private void UpdateTotalScore(int now, int total, int best)         // ���� ���� ����
    {
        totalScore.text = total.ToString();
    }

    private void UpdateBestScore(int now, int total, int best)          // �ְ� ���� ����
    {
        bestScore.text = best.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
