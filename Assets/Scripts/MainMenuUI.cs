using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    GameManager gm;
    public GameObject player;
    public GameObject cp;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Play()
    {
        gm.addHighscore = true;
        gm.lives = 3;
        gm.level = 1;
        gm.ChangeState(GameManager.GameState.GAME);
        player.transform.position = new Vector3(-8f, 0.5f, 0f);
        gm.lastCheckpoint = player.transform.position;
        gm.score = player.transform.position.y * 10;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -9.8f);
        GameObject c = Instantiate(cp, new Vector3(3f, 16.3f, 0f), Quaternion.identity); // Checkpoint Level 2
        Checkpoint checkpoint = c.GetComponent<Checkpoint>();
        checkpoint.checkpoint_level = 2;
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