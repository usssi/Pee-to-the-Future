using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisolvedorDePastilla : MonoBehaviour
{
    [HideInInspector] public float scaleSpeed; 
    private Vector3 targetScale;

    [HideInInspector] public bool isDisolved;

    public Material rojoFuerte;
    public Material verdeFuerte;
    public Material rojoNatural;

    public bool isWin;
    public bool isLose;
    public float deadSize;



    private void Start()
    {
        scaleSpeed = FindObjectOfType<ControladorDePastillas>().disolveMultiplier;
        targetScale = Vector3.zero;
        float randomScale = Random.Range(-0.02f, 0.05f);
        transform.localScale += new Vector3(randomScale, randomScale, randomScale);
    }

    private void Update()
    {
        if (!isWin)
        {
            GetComponent<MeshRenderer>().material = rojoNatural;
        }
        else
        {
            GetComponent<MeshRenderer>().material = verdeFuerte;
        }
        if (isLose)
        {
            GetComponent<MeshRenderer>().material = rojoFuerte;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (transform.localScale.x >= deadSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
            GetComponent<MeshRenderer>().material = rojoFuerte;

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
