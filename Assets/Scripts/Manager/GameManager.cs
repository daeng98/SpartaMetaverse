using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public void StartGame()         // 게임 시작
    {
        UIManager.Instance.ResetNowScore();
        SceneManager.LoadScene("MiniGameScenes");
    }

    public void ExitGame()          // 나가기
    {
        SceneManager.LoadScene("MainScenes");
    }

}
