using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [HideInInspector] public float puntosContados;
    private bool isColliding = false;

    public float baseSpeed = 1.0f; 
    public float minSpeedMultiplier = 1.0f; 
    public float maxSpeedMultiplier = 2.0f;

    public bool canPeeGoDown;

    private void OnParticleCollision(GameObject other)
    {
        float speedMultiplier = Mathf.Lerp(maxSpeedMultiplier, minSpeedMultiplier, puntosContados / 100f);

        puntosContados += speedMultiplier * Time.deltaTime;

        if (other.gameObject == gameObject)
        {
            isColliding = true;
        }
    }

    private void Update()
    {
        if (!isColliding)
        {
            if (canPeeGoDown)
            {
                MakePointGoDown();
            }
        }
        else
        {
            isColliding = false;
        }
    }

    void MakePointGoDown()
    {
        if (puntosContados > 0)
        {
            //float speedMultiplier = Mathf.Lerp(maxSpeedMultiplier, minSpeedMultiplier, puntosContados / 100f);

            puntosContados -= Time.deltaTime;
        }
        else if (puntosContados<=0)
        {
            puntosContados = 0;
        }
    }
}
