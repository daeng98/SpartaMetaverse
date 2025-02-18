using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UIState
{
    Main,
    How
}

public class UIManager : MonoBehaviour
{
    MainUI main;
    HowtoUI how;

    public TextMeshProUGUI Score;

    private UIState currentState;

    private void Awake()
    {
        main = GetComponentInChildren<MainUI>(true);
        main.Init(this);
        how = GetComponentInChildren<HowtoUI>(true);
        how.Init(this);

        ChangeState(UIState.Main);
    }

    public void SetHow()
    {
        ChangeState(UIState.How);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        main.SetActive(currentState);
        how.SetActive(currentState);
    }

    public void UpdateScore(int score)
    {
        Score.text = score.ToString();
    }
}
