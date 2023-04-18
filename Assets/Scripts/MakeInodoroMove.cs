using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInodoroMove : MonoBehaviour
{
    [Header("Move Inodoro")]
    public bool moveInodoro;
    public bool moveX;
    public bool moveY;
    public bool moveZ;

    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 lerPosition;

    public float speed = 1.0f;
    private float t = 0.0f;

    void Start()
    {
        lerPosition = transform.position;
    }

    void Update()
    {
        if (moveInodoro)
        {
            if (moveX)
            {
                MakeInodoroMoveOnX();
            }
        }
    }

    void MakeInodoroMoveOnX()
    {
        t += Time.deltaTime * speed;

        lerPosition.x = Mathf.Lerp(startPosition.x, endPosition.x, Mathf.PingPong(t, 1.0f));
        transform.position = lerPosition;
    }
}
