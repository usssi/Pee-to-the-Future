using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public float points;
    public int pointsToWin;

    public TextMeshProUGUI textoPuntos;

    public GameObject diana;


    private void Update()
    {
        points = diana.GetComponent<DetectMouseOverDiana>().puntosContados;

        textoPuntos.text = "Puntos: " + points.ToString("0") + "/" + pointsToWin;
    }
}
