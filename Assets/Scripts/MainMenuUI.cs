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
        gm.time = 0;
        gm.addHighscore = true;
        gm.lives = 3;
        gm.level = 1;
        gm.score = 0f;
        player.transform.position = new Vector3(-8f, 0.5f, 0f);
        gm.lastCheckpoint = player.transform.position;
        gm.ChangeState(GameManager.GameState.GAME);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -9.8f);
        GameObject c2 = Instantiate(cp, new Vector3(33.13f, 3.37f, 0f), Quaternion.identity); // Checkpoint Level 2
        Checkpoint checkpoint2 = c2.GetComponent<Checkpoint>();
        checkpoint2.checkpoint_level = 2;
        GameObject c3 = Instantiate(cp, new Vector3(-9f, 40.95f, 0f), Quaternion.identity); // Checkpoint Level 3
        Checkpoint checkpoint3 = c3.GetComponent<Checkpoint>();
        checkpoint3.checkpoint_level = 3;
        GameObject c4 = Instantiate(cp, new Vector3(48f, 51.35f, 0f), Quaternion.identity); // Checkpoint Level 4
        Checkpoint checkpoint4 = c4.GetComponent<Checkpoint>();
        checkpoint4.checkpoint_level = 4;
        GameObject c5 = Instantiate(cp, new Vector3(-18.55f, 71.55f, 0f), Quaternion.identity); // Checkpoint Level 5
        Checkpoint checkpoint5 = c5.GetComponent<Checkpoint>();
        checkpoint5.checkpoint_level = 5;
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