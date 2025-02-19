using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentScore = 0;

    private UIManager uiManager;

    private void Awake()
    {
        Instance = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    public void Start()
    {
        uiManager.UpdateScore(0);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("MiniGameScenes"); // ¾À ºÒ·¯¿À±â
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainScenes"); // ¾À ºÒ·¯¿À±â
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
    }
}
