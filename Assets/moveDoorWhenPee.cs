using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDoorWhenPee : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float rotationAngle = 120f;

    private bool isRotating = false;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        StartCoroutine(RotateObject());

    }

    private IEnumerator RotateObject()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);

        float elapsedTime = 0f;

        while (elapsedTime < rotationSpeed)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
