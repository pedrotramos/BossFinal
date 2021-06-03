using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gm;
    public int checkpoint_level;
    public AudioClip checkpointSFX;

    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        gm.lastCheckpoint = transform.position;
        gm.level = checkpoint_level;
        gameObject.SetActive(false);
        AudioManager.PlaySFX(checkpointSFX, 0.2f);
    }
}
