using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraOnStart : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
    private Vector3 originalPosition;


    void Start()
    {
        InvokeRepeating("ChangeDirection", 0f, 1f);
        originalPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (Time.timeScale == 0)
        {
            transform.position += moveDirection * speed * Time.unscaledDeltaTime;
        }
        if (Time.timeScale == 1)
        {
            transform.position = originalPosition;
            InvokeRepeating("ChangeDirection", 0f, 1f);
        }
    }

    void ChangeDirection()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                moveDirection = Vector3.right;
                break;
            case 1:
                moveDirection = Vector3.left;
                break;
            case 2:
                moveDirection = Vector3.forward;
                break;
            case 3:
                moveDirection = Vector3.back;
                break;
        }
    }
}
