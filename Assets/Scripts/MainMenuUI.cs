using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    GameManager gm;
    public GameObject player;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Play()
    {
        gm.addHighscore = true;
        gm.lives = 3;
        gm.ChangeState(GameManager.GameState.GAME);
        player.transform.position = new Vector3(-8f, 0f, 0f);
        gm.lastCheckpoint = player.transform.position;
        gm.score = player.transform.position.y * 10;
    }

    public void ChangeSettings()
    {
        gm.ChangeState(GameManager.GameState.SETTINGS);
    }

    public void ShowInstructions()
    {
        gm.ChangeState(GameManager.GameState.INSTRUCTIONS);
    }

}