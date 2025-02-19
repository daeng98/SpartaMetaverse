using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        restartButton.onClick.AddListener(OnClickReStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickReStartButton()
    {
        ResetNowScore();
        GameManager.Instance.StartGame();
    }

    public void OnClickExitButton()
    {
        ResetNowScore();
        GameManager.Instance.ExitGame();
    }

    public void ResetNowScore()
    {
        GameManager.Instance.nowScore = 0;
        UIManager.Instance.nowScore.text = "0";
    }
    protected override UIState GetUIState()
    {
        return UIState.Result;
    }
}
