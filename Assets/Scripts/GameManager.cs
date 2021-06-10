using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    private static GameManager _instance;

    public enum GameState { MENU, GAME, ENDGAME, PAUSE, SETTINGS, INSTRUCTIONS };

    public GameState gameState { get; private set; }
    public float score;
    public int time;
    public int lives;
    public int level;
    public Vector3 lastCheckpoint;
    public bool win;
    public bool addHighscore;
    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        gameState = nextState;
        changeStateDelegate();
    }

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        win = false;
        gameState = GameState.MENU;
    }

}