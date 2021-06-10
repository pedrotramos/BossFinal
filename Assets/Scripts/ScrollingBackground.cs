using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private Transform centerBG;

    [SerializeField]
    private float xRef;

    [SerializeField]
    private float yRef;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= centerBG.position.y + yRef)
        {
            centerBG.position = new Vector3(centerBG.position.x, transform.position.y + yRef, -5f);
        }
        else if (transform.position.y <= centerBG.position.y - yRef)
        {
            centerBG.position = new Vector3(centerBG.position.x, transform.position.y - yRef, -5f);
        }

        if (transform.position.x >= centerBG.position.x + xRef)
        {
            centerBG.position = new Vector3(transform.position.x + xRef, centerBG.position.y, -5f);
        }
        else if (transform.position.x <= centerBG.position.x - xRef)
        {
            centerBG.position = new Vector3(transform.position.x - xRef, centerBG.position.y, -5f);
        }
    }
}
