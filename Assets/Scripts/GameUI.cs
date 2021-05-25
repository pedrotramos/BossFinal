using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text lives;
    public Text score;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        lives.text = $"Lives: {Mathf.Round(gm.lives)}";
        score.text = $"Score: {Mathf.Round(gm.score)}";
    }
}
