using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gm;
    public AudioClip jumpSFX;
    public AudioClip stuckSFX;
    public AudioClip iceLandingSFX;
    public AudioClip bounceSFX;
    public AudioClip dieSFX;
    public PlayerAim aim;
    public Rigidbody2D rb;
    public bool canJump = false;
    bool stuckToMoving = false;
    GameObject parentObj;
    Vector3 distToParent;
    float timer;
    ContactPoint2D[] contacts;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f);
        timer = 0f;
        contacts = new ContactPoint2D[1];
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME)
        {
            return;
        }
        if (transform.position.y < -2f)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        if (transform.position.y * 10 > gm.score) gm.score = transform.position.y * 10;
        int collisionCount = rb.GetContacts(contacts);
        if (Input.GetKeyDown(KeyCode.Space) && canJump && collisionCount > 0 && aim.AimSprite.activeSelf)
        {
            canJump = false;
            stuckToMoving = false;
            Physics2D.gravity = new Vector2(0f, -9.8f);
            Vector2 direction = aim.GetAimDirection();
            float force = 400f;
            rb.AddForce(direction * force);
            AudioManager.PlaySFX(jumpSFX, 0.2f);
        }
        if (stuckToMoving)
        {
            Vector3 parentPos = parentObj.transform.position;
            transform.position = parentPos - distToParent;
        }
    }


    void Die()
    {
        transform.position = gm.lastCheckpoint;
        rb.velocity = new Vector2(0f, -9.8f);
        canJump = false;
        gm.lives--;
        AudioManager.PlaySFX(dieSFX, 1f);
        if (gm.lives <= 0)
        {
            gm.win = false;
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Sticky")
        {
            canJump = true;
            rb.velocity = new Vector2(0f, 0f);
            Physics2D.gravity = new Vector2(0f, 0f);
            AudioManager.PlaySFX(stuckSFX, 1f);
        }

        else if (col.collider.gameObject.tag == "MovingSticky")
        {
            canJump = true;
            stuckToMoving = true;
            parentObj = col.gameObject;
            distToParent = parentObj.transform.position - transform.position;
            rb.velocity = new Vector2(0f, 0f);
            Physics2D.gravity = new Vector2(0f, 0f);
            AudioManager.PlaySFX(stuckSFX, 1f);
        }

        else if (col.collider.gameObject.tag == "Ice")
        {
            canJump = true;
            AudioManager.PlaySFX(iceLandingSFX, 1f);
        }

        else if (col.collider.gameObject.tag == "Bounce")
        {
            AudioManager.PlaySFX(bounceSFX, 1f);
        }

        else if (col.collider.gameObject.tag == "Spike")
        {
            Die();
        }
    }
}
