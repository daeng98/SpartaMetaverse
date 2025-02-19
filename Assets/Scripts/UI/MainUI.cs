using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : BaseUI
{
    private void Start()
    {
        this.SetActive(UIState.Main);
    }

    protected override UIState GetUIState()
    {
        return UIState.Main;
    }
}
