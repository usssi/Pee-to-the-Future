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

    private bool hasplayedDoor;
    private bool hasplayedMystery;


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
        if (!hasplayedDoor)
        {
            FindObjectOfType<AudioManager>().Play("door", 1f);
            FindObjectOfType<AudioManager>().Play("door2", 1f);
            hasplayedDoor = true;
        }



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
        if (!hasplayedMystery)
        {
            FindObjectOfType<AudioManager>().Play("futuremystery", 1f);
            hasplayedMystery = true;
        }

    }
}
