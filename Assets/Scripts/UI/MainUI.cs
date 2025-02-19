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

    private void Start()
    {
        Debug.Log("totalScore Main Scene: " + totalScore.text);
        Debug.Log("bestScore Main Scene: " + bestScore.text); 
        Debug.Log("MainUI instances: " + FindObjectsOfType<MainUI>().Length);
    }

    private void OnEnable()
    {
        UIManager.OnScoreUpdated -= UpdateTotalScore;
        UIManager.OnScoreUpdated -= UpdateBestScore;
        Debug.Log("MainUI OnScoreUpdated OnDisable");
        UIManager.OnScoreUpdated += UpdateTotalScore;
        UIManager.OnScoreUpdated += UpdateBestScore;
        Debug.Log("MainUI OnScoreUpdated OnEnable");
    }

    //private void OnEnable()
    //{
    //    UIManager.OnScoreUpdated += UpdateTotalScore;
    //    UIManager.OnScoreUpdated += UpdateBestScore;
    //    Debug.Log("MainUI OnScoreUpdated OnEnable");
    //}

    //private void OnDisable()
    //{
    //    UIManager.OnScoreUpdated -= UpdateTotalScore;
    //    UIManager.OnScoreUpdated -= UpdateBestScore;
    //    Debug.Log("MainUI OnScoreUpdated OnDisable");
    //}

    private void UpdateTotalScore(int now, int total, int best)
    {
        //if (totalScore == null)
        //{
        //    Debug.LogError("TotalScore : NULL");
        //}

        totalScore.text = total.ToString();
    }

    private void UpdateBestScore(int now, int total, int best)
    {
        //if (bestScore == null)
        //{
        //    Debug.LogError("bestScore : NULL");
        //}

        bestScore.text = best.ToString();
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
