using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGame : MonoBehaviour
{

    public Points pointController;
    public pissController pisController;
    public IntensityController intensityController;

    public float velocidadDePipi;

    private void Update()
    {
        pisController.MakePisGoDown(velocidadDePipi);
    }
}
