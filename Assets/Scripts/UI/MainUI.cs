using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    [SerializeField] public TextMeshProUGUI totalScore;

    private void Awake()
    {
        Debug.Log("MainUI Awake �����!");
        Debug.Log($"Awake���� TotalScore: {totalScore}");
        UIManager.OnScoreUpdated += UpdateTotalScore;
    }

    private void Start()
    {
        Debug.Log("MainUI Start �����!");
        Debug.Log($"Start���� TotalScore: {totalScore}");
    }

    private void UpdateTotalScore(int now, int total)
    {
        if (totalScore == null)
        {
            Debug.LogError("TotalScore : NULL");
        }

        totalScore.text = total.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
