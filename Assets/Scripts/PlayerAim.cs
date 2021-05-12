using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    GameObject aimTransform;
    Vector2 aimDirection;

    void Awake()
    {
        aimTransform = GameObject.FindGameObjectWithTag("Aim");
    }

    // Update is called once per frame
    void Update()
    {
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
