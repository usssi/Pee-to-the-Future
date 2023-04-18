using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerEnterChangeColor : MonoBehaviour
{
    public Material materialVictoria;
    public Material materialDerrota;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "pichi")
        {
            print("azulVictoria");
            GetComponent<MeshRenderer>().material = materialVictoria;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "pichi")
        {
            print("rojoderrota");

            GetComponent<MeshRenderer>().material = materialDerrota;
        }
    }
}
