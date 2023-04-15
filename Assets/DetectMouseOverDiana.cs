using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOverDiana : MonoBehaviour
{
    public float  puntosContados;
    public int multiplicadorDePuntos;

    private void OnMouseOver()
    {
        Debug.Log("El cursor está por encima de este objeto con tag diana.");

        puntosContados += multiplicadorDePuntos * Time.deltaTime;

    }
}
