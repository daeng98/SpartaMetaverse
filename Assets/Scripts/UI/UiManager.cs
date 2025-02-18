using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI restratTxt;

    void Start()
    {
        if (scoreTxt == null)
            Debug.LogError("score text is null");
        if (restratTxt == null)
            Debug.LogError("restrat text is null");
    }

    public void SetRestart()
    {
        restratTxt.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }
}
