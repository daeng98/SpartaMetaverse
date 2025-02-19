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
        Debug.Log("MainUI Awake ½ÇÇàµÊ!");
        Debug.Log($"Awake¿¡¼­ TotalScore: {totalScore}");
        UIManager.OnScoreUpdated += UpdateTotalScore;
    }

    private void Start()
    {
        Debug.Log("MainUI Start ½ÇÇàµÊ!");
        Debug.Log($"Start¿¡¼­ TotalScore: {totalScore}");
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
