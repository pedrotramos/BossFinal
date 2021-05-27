using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameManager gm;
    public int checkpoint_level;

    void Start()
    {
        gm = GameManager.GetInstance();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        gm.lastCheckpoint = transform.position;
        gm.level = checkpoint_level;
        gameObject.SetActive(false);
    }
}
