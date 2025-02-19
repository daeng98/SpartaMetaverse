using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int nowScore = 0;
    private int totalScore = 0;

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
    }

    public void Start()
    {
        UIManager.Instance.UpdateScore(0, 0);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("MiniGameScenes");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScenes");
    }

    public void AddScore(int score)
    {
        nowScore += score;
        totalScore += score;
        UIManager.Instance.UpdateScore(nowScore, totalScore);
    }
}
