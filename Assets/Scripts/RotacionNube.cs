using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionNube : MonoBehaviour
{
    public float velocidadRotacion = 1.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto en torno al eje Y de forma continua
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}

