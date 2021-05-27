using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text lives;
    public Text score;
    public Text level;
    GameManager gm;
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        lives.text = $"Lives: {gm.lives}";
        lives.text = $"Level: {gm.level}";
        score.text = $"Score: {Mathf.Round(gm.score)}";
    }
}
