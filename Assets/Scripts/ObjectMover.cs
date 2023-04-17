using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minZ = -5.0f;
    public float maxZ = 5.0f;

    public float minSpeed;
    public float maxSpeed;

    public float minTriggerTime = 2.0f;
    public float maxTriggerTime = 5.0f;

    private float nextTriggerTime;
    private Vector3 targetPosition;

    void Start()
    {
        nextTriggerTime = 5;
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        if (Time.time >= nextTriggerTime)
        {
            targetPosition = GetRandomPosition();
            nextTriggerTime = Time.time + Random.Range(minTriggerTime, maxTriggerTime);
            transform.position = targetPosition;
        }
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * Random.Range(minSpeed, maxSpeed));
    }

    private Vector3 GetRandomPosition()
    {
        float ngegativeOrpositive = Random.Range(0, 1);
        if (ngegativeOrpositive == 1)
        {
            float x = Random.Range(minX, maxX);
            return new Vector3(x, transform.position.y, -0.33f);
        }
        else
        {
            float x = Random.Range(minZ, maxZ);
            return new Vector3(x, transform.position.y, -0.33f);
        }
    }
}
