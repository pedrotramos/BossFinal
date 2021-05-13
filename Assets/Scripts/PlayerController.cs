using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerAim aim;
    public Rigidbody2D rb;
    public bool stuck = false;
    float timer;
    ContactPoint2D[] contacts;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f);
        timer = 0f;
        contacts = new ContactPoint2D[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stuck)
        {
            stuck = false;
            Physics2D.gravity = new Vector2(0f, -9.8f);
            Vector2 direction = aim.GetAimDirection();
            float force = 400f;
            rb.AddForce(direction * force);
        }

        int collisionCount = rb.GetContacts(contacts);
        if (collisionCount > 0)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }

        if (timer > 1f)
        {
            stuck = true;
            rb.velocity = new Vector2(0f, 0f);
            timer = 0f;
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.tag == "Sticky")
        {
            stuck = true;
            rb.velocity = new Vector2(0f, 0f);
            Physics2D.gravity = new Vector2(0f, 0f);
        }
    }

    // void OnCollisionStay2D(Collision2D col)
    // {
    //     if (col.collider.gameObject.tag == "Sticky")
    //     {
    //         stuck = true;
    //     }
    // }

    // void OnCollisionExit2D(Collision2D col)
    // {
    //     stuck = false;
    // }
}
