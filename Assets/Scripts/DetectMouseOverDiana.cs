using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouseOverDiana : MonoBehaviour
{
    public float  puntosContados;
    public int multiplicadorDePuntos;

    //private void OnMouseOver()
    //{
    //    Debug.Log("estas apuntando al agua");

    //    puntosContados += multiplicadorDePuntos * Time.deltaTime;

    //}

    private void OnParticleCollision(GameObject other)
    {
        print("pis choca con diana");
        puntosContados += multiplicadorDePuntos * Time.deltaTime;

    }
}
