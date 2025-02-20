using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] public TextMeshProUGUI Score;
    [SerializeField] public TextMeshProUGUI bestScore;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        restartButton.onClick.AddListener(OnClickReStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void Update()
    {
        Score.text = UIManager.Instance.nowScore.ToString();
        bestScore.text = UIManager.Instance.bestScore.ToString();
    }

    private void OnClickReStartButton()
    {
        GameManager.Instance.StartGame();
    }

    private void OnClickExitButton()
    {
        GameManager.Instance.ExitGame();
    }

    protected override UIState GetUIState()
    {
        return UIState.Result;
    }
}
