using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameFlag : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        gm.win = true;
        gm.ChangeState(GameManager.GameState.ENDGAME);
    }
}
