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
    private int bestScore = 0;
    public int totalScore = 0;

    private UIState currentState;

    public static UIManager Instance;

    public static event Action<int, int, int> OnScoreUpdated;

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

    public void UpdateScore(int now, int total, int best)
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
    public void AddScore(int score)
    {
        nowScore += score;
        totalScore += score;

        if (bestScore < nowScore)
        {
            bestScore = nowScore;
        }

        UpdateScore(nowScore, totalScore, bestScore);
    }

    public void ResetNowScore()
    {
        nowScore = 0;

        OnScoreUpdated?.Invoke(nowScore, totalScore, bestScore);
    }
}
