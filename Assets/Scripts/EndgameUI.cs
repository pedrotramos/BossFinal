using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameUI : MonoBehaviour
{
    public Text message;
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.win)
        {
            message.text = "Congratulations, you won and scored " + Mathf.Round(gm.score).ToString() + " points!";
        }
        else
        {
            message.text = "Game over! You have scored " + Mathf.Round(gm.score).ToString() + " points!";
        }
    }

    public void BackToMainMenu()
    {
        gm.score = 0;
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
