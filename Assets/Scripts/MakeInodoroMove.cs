using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInodoroMove : MonoBehaviour
{
    [Header("Move Inodoro")]
    public bool moveInodoro;
    public Transform inodoro;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;
    private float t = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        MakeInodoroMoveFunction();
    }

    void MakeInodoroMoveFunction()
    {
        t += Time.deltaTime * speed;
        inodoro.transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(t, 1.0f));
    }
}
