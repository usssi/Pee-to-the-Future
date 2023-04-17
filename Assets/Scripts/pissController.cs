using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pissController : MonoBehaviour
{
    public float Progress => progress;
    private float progress = 100;
    public Image barraDePipi;

    public GameObject panza;
    public float maxScaleZ = 0.9f;
    public float minScaleZ = 0.6f;

    public void MakePisGoDown(float velocidadDeHacerPipi)
    {
        barraDePipi.fillAmount = progress / 100f;
        progress -= velocidadDeHacerPipi * Time.deltaTime;
    }

    public void MakePanzaGoDown(float velocidadDeHacerPipi)
    {
        progress -= velocidadDeHacerPipi * Time.deltaTime;

        // Calculate the new scale value based on the progress
        float t = progress / 100f;
        float newScaleZ = Mathf.Lerp(minScaleZ, maxScaleZ, t);

        // Set the new scale value for the panza game object
        Vector3 newScale = panza.transform.localScale;
        newScale.z = newScaleZ;
        panza.transform.localScale = newScale;

    }
}