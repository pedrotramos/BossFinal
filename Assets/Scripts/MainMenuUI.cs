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
        gm.lives = 3;
        gm.ChangeState(GameManager.GameState.GAME);
        player.transform.position = new Vector3(0f, 0.6f, 0f);
        gm.lastCheckpoint = player.transform.position;
        gm.score = player.transform.position.y * 100;
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