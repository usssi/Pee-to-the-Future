using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class pissController : MonoBehaviour
{
    public float progress = 0f;
    public float velocidadDeHacerPipi;
    public Image progressBar;

    private void Start()
    {

    }

    private void Update()
    {
        progressBar.fillAmount = progress / 100f;

        progress -= velocidadDeHacerPipi * Time.deltaTime;
    }
}
