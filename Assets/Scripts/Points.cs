using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Progress;

public class Points : MonoBehaviour
{
    [HideInInspector] public float points;

    [HideInInspector] public int pointsToWin;
    [HideInInspector] public float pointMultiplier;
    public float pointSubstractorPerFrame;

    public TextMeshProUGUI textoPuntos;

    public List<PointCounter> pointCounters = new List<PointCounter>();

    private void Start()
    {
        PointCounter[] foundPointCounters = FindObjectsOfType<PointCounter>();

        foreach (PointCounter pointCounter in foundPointCounters)
        {
            pointCounters.Add(pointCounter);
        }
    }

    private void Update()
    {
        foreach (var item in pointCounters)
        {
            points = item.GetComponent<PointCounter>().puntosContados;
        }

        textoPuntos.text = "Lleno: " + points.ToString("0") + "%";

        //MakePointGoDown();
    }

    void MakePointGoDown()
    {
        if (points>0)
        {
            foreach (var item in pointCounters)
            {
                item.GetComponent<PointCounter>().puntosContados -= Time.deltaTime * pointSubstractorPerFrame;
            }
        }
        else if (points<=0)
        {
            foreach (var item in pointCounters)
            {
                item.GetComponent<PointCounter>().puntosContados = 0;
            }
        }
    }
}
