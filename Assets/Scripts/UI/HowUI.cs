using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowUI : BaseUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()    // 시작 버튼 눌렀을때
    {
        GameManager.Instance.StartGame();
    }

    public void OnClickExitButton()     // 나가기 버튼 눌렀을때
    {
        this.SetActive(UIState.Main);
    }

    protected override UIState GetUIState()
    {
        return UIState.How;
    }
}
