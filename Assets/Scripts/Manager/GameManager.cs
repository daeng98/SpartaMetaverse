using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gm;
    public static GameManager Instance { get { return gm; } }

    private int currentScore = 0;

    UiManager um;
    public UiManager UiManager { get { return um; } }

    private void Awake()
    {
        gm = this;
        um = FindObjectOfType<UiManager>();
    }

    public void Start()
    {
        um.UpdateScore(0);
    }

    public void GameOver()
    {
        um.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // �� �ҷ�����
    }

    public void AddScore(int score)
    {
        currentScore += score;
        um.UpdateScore(currentScore);
    }
}
