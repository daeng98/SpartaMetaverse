using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Main,
    Game,
    Result,
    How
}

public class UIManager : MonoBehaviour
{
    MainUI main;
    GameUI game;
    ResultUI result;
    HowtoUI how;

    public TextMeshProUGUI Score;

    private UIState currentState;

    private void Awake()
    {
        main = GetComponentInChildren<MainUI>(true);
        main.Init(this);
        //game = GetComponentInChildren<GameUI>(true);
        //game.Init(this);
        //result = GetComponentInChildren<ResultUI>(true);
        //result.Init(this);
        how = GetComponentInChildren<HowtoUI>(true);
        how.Init(this);

        ChangeState(UIState.Main);
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
    }
    public void SetResult()
    {
        ChangeState(UIState.Result);
    }
    public void SetHow()
    {
        ChangeState(UIState.How);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        main.SetActive(currentState);
        //game.SetActive(currentState);
        //result.SetActive(currentState);
        how.SetActive(currentState);
    }

    public void UpdateScore(int score)
    {
        Score.text = score.ToString();
    }
}
