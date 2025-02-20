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

    public int nowScore = 0;
    public int bestScore = 0;
    public int totalScore = 0;

    private UIState currentState;

    public static UIManager Instance;

    public static event Action<int, int, int> OnScoreUpdated;       // 점수 관리를 위한 이벤트

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

    public void ChangeState(UIState state)      // UI 전환
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

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)      // 씬에 따라 초기에 보여지는 UI설정
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

    public void UpdateScore(int now, int total, int best)       // 점수 갱신
    {
        nowScore = now;
        totalScore = total;

        if(bestScore < nowScore)
        {
            bestScore = nowScore;
        }

        Debug.Log($"[UIManager] UpdateScore : now={nowScore}, total={totalScore}, best={bestScore}");
        OnScoreUpdated?.Invoke(nowScore, totalScore, bestScore);
    }

    public void AddScore(int score)     // 점수 추가
    {
        nowScore += score;
        totalScore += score;

        if (bestScore < nowScore)
        {
            bestScore = nowScore;
        }

        UpdateScore(nowScore, totalScore, bestScore);
    }

    public void ResetNowScore()     // 현재 점수 초기화
    {
        nowScore = 0;

        OnScoreUpdated?.Invoke(nowScore, totalScore, bestScore);
    }
}
