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

    public void MakePisGoDown(float velocidadDeHacerPipi)
    {
        barraDePipi.fillAmount = progress / 100f;

        progress -= velocidadDeHacerPipi * Time.deltaTime;
    }
}
