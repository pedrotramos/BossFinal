using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    GameManager gm;
    GameObject aimTransform;
    Vector2 aimDirection;
    public PlayerController controller;
    public GameObject AimSprite;
    ContactPoint2D[] contacts;

    void Awake()
    {
        aimTransform = GameObject.FindGameObjectWithTag("Aim");
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
        controller.GetComponent<Rigidbody2D>().GetContacts(contacts);
        Vector2 normal_vec = contacts[0].normal;
        float normal_angle = Vector2.Angle(aimDirection, normal_vec);
        if (controller.canJump && normal_angle < 87f)
        {
            AimSprite.SetActive(true);
        }
        else
        {
            AimSprite.SetActive(false);
        }
        Vector3 mousePos = GetMouseWorldPosition();
        Vector2 pos = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        aimDirection = pos.normalized;
        float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90f;
        float xVal = transform.position.x + (aimDirection.x * 0.7f);
        float yVal = transform.position.y + (aimDirection.y * 0.7f);
        aimTransform.transform.position = new Vector2(xVal, yVal);
        aimTransform.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return pos;
    }

    public Vector2 GetAimDirection()
    {
        return aimDirection;
    }
}
