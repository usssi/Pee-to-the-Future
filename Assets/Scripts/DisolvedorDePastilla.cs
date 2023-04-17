using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolvedorDePastilla : MonoBehaviour
{
    [HideInInspector] public float scaleSpeed; 
    private Vector3 targetScale;

    [HideInInspector] public bool isDisolved;

    private void Start()
    {
        scaleSpeed = FindObjectOfType<ControladorDePastillas>().disolveMultiplier;

        targetScale = Vector3.zero;

        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

        float randomScale = Random.Range(-0.03f, 0.08f);
        transform.localScale += new Vector3(randomScale, 0, randomScale);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (transform.localScale.x >= 0.07)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
        }
        else
        {
            isDisolved = true;
            transform.localScale = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "piso")
        {
            isDisolved = true;
            transform.localScale = Vector3.zero;
        }
    }
}
