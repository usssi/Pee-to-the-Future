using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerEnterChangeColor : MonoBehaviour
{
    public Material materialVictoria;
    public Material materialDerrota;
    public float pitchChanger = 1;
    public changePitchRegla pitchChangerRule;

    private void Start()
    {
        pitchChangerRule = FindObjectOfType<changePitchRegla>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "pichi")
        {
            print("verdeVictoria");
            GetComponent<MeshRenderer>().material = materialVictoria;
            FindObjectOfType<AudioManager>().Play("confirm", pitchChangerRule.contadorPuntos);
            pitchChangerRule.contadorPuntos += .1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "pichi")
        {
            print("rojoderrota");
            FindObjectOfType<AudioManager>().Play("decline", pitchChangerRule.contadorPuntos);
            GetComponent<MeshRenderer>().material = materialDerrota;
            pitchChangerRule.contadorPuntos -= .1f;
        }
    }
}
