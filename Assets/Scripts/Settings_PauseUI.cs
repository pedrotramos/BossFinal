using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_PauseUI : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void BackToMainMenu()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }

    public void ResumeGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}