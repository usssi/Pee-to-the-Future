using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectGameplayRunnerMover : MonoBehaviour
{
    public float lerpSpeed = 1f;
    private float timeElapsed = 0f;
    public bool canMove;
    public bool canRotate;

    public float rotateSpeed;

    public Transform spawnPoint;
    public Transform despawnPoint;

    void Start()
    {

    }

    void Update()
    {
        if (canMove)
        {
            MoveFicha();
        }

        if (canRotate)
        {
            RotateFichaZ();
        }
    }

    public void MoveFicha()
    {
        timeElapsed += Time.deltaTime;
        float t = timeElapsed / lerpSpeed;
        float xX = transform.position.x;
        Vector3 startPosition = new Vector3(xX, spawnPoint.position.y, spawnPoint.position.z);
        Vector3 endPosition = new Vector3(xX, despawnPoint.position.y, despawnPoint.position.z);
        transform.position = Vector3.Lerp(startPosition, endPosition, t);

        if (transform.position == endPosition)
        {
            this.gameObject.SetActive(false);
        }
    }

    void RotateFichaZ()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
