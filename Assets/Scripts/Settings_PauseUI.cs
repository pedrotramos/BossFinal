using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_PauseUI : MonoBehaviour
{
    GameManager gm;
    GameObject player;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void BackToMainMenu()
    {
        player.transform.position = new Vector3(-8f, 0f, 0f);
        gm.score = 0f;
        gm.ChangeState(GameManager.GameState.MENU);
    }

    public void ResumeGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}