using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [HideInInspector] public float points;
    [HideInInspector] public int pointsToWin;
    [HideInInspector] public float pointMultiplier;


    public TextMeshProUGUI textoPuntos;

    public GameObject diana;


    private void Update()
    {
        points = diana.GetComponent<detectParticleCollision>().puntosContados * pointMultiplier;

        textoPuntos.text = "Puntos: " + points.ToString("0") + "/" + pointsToWin;
    }
}
