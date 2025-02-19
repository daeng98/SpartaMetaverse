using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState
{
    Main,
    How,
    Game,
    Result
}

public class UIManager : MonoBehaviour
{
    MainUI main;
    HowUI how;
    GameUI game;
    ResultUI result;

    private int nowScore = 0;
    private int totalScore = 0;

    private UIState currentState;

    public static UIManager Instance;

    public static event Action<int, int> OnScoreUpdated;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitUI();

        ChangeState(UIState.Main);
    }

    private void InitUI()
    {
        main = GetComponentInChildren<MainUI>(true);
        if (main != null)
            main.Init(this);

        how = GetComponentInChildren<HowUI>(true);
        if (how != null)
            how.Init(this);

        game = GetComponentInChildren<GameUI>(true);
        if (game != null)
            game.Init(this);

        result = GetComponentInChildren<ResultUI>(true);
        if (result != null)
            result.Init(this);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;

        if (main != null)
            main.SetActive(currentState);

        if (how != null)
            how.SetActive(currentState);

        if (game != null)
            game.SetActive(currentState);

        if (result != null)
            result.SetActive(currentState);
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "MiniGameScenes")
        {
            ChangeState(UIState.Game);
        }
        else if (scene.name == "MainScenes")
        {
            ChangeState(UIState.Main);
        }
    }

    public void UpdateScore(int now, int total)
    {
        if (main == null)
        {
            main = FindObjectOfType<MainUI>();
            if (main == null)
            {
                Debug.LogError("MainUI를 찾을 수 없습니다.");
                return;
            }
        }

        if (main.totalScore == null)
        {
            Debug.LogError("TotalScore가 NULL입니다.");
            return;
        }

        nowScore = now;
        totalScore = total;

        Debug.Log($"[UIManager] UpdateScore 호출됨: now={nowScore}, total={totalScore}");

        OnScoreUpdated?.Invoke(nowScore, totalScore);
    }

    public void ResetNowScore()
    {
        nowScore = 0;
        GameManager.Instance.nowScore = 0;

        OnScoreUpdated?.Invoke(nowScore, totalScore);
    }
}
