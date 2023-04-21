using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ToggleParticleRenderer : MonoBehaviour
{
    public bool toggleRednerer;
    public GameObject particula;

    public float maxLife;
    public float minLife;
    public float maxSize;
    public float minSize;


    private void OnParticleCollision(GameObject other)
    {
        GameObject particleSystemObject = particula;
        if (particula != null)
        {
            ParticleSystem particleSystem = particleSystemObject.GetComponent<ParticleSystem>();
            MainModule mainModule = particleSystem.main;
            MinMaxCurve startLifetime = mainModule.startLifetime;
            MinMaxCurve startSize = mainModule.startSize;
            startLifetime.constantMax = maxLife;
            startLifetime.constantMin = minLife;

            startSize.constantMax = maxSize;
            startSize.constantMin = minSize;

            mainModule.startLifetime = startLifetime;
            mainModule.startSize = startSize;
        }
        else
        {
            GameObject particleSystemObjectFound = GameObject.FindGameObjectWithTag("salpicadura");
            particula = particleSystemObjectFound;

            ParticleSystem particleSystem = particleSystemObjectFound.GetComponent<ParticleSystem>();
            MainModule mainModule = particleSystem.main;
            MinMaxCurve startLifetime = mainModule.startLifetime;
            MinMaxCurve startSize = mainModule.startSize;
            startLifetime.constantMax = maxLife;
            startLifetime.constantMin = minLife;

            startSize.constantMax = maxSize;
            startSize.constantMin = minSize;

            mainModule.startLifetime = startLifetime;
            mainModule.startSize = startSize;
        }
    }
}
