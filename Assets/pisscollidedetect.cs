using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisscollidedetect : MonoBehaviour
{
    public bool canPlayPiso;
    public bool canPlayPismal;
    public bool canPlayPointcounter;

    public bool hasPlayPiso;
    public bool hasPlayPismal;
    public bool hasPlayPointcounter;


    // Update is called once per frame
    void Update()
    {
        if (canPlayPiso)
        {
            if (!hasPlayPiso)
            {
                print("play charco");

                FindObjectOfType<AudioManager>().Play("pisSUELO",1f);
                hasPlayPiso = true;
            }
        }

        if (canPlayPismal)
        {
            if (!hasPlayPismal)
            {
                print("play rebotar");

                FindObjectOfType<AudioManager>().Play("pisborde", 1f);

                hasPlayPismal = true;
            }
        }

        if (canPlayPointcounter)
        {
            if (!hasPlayPointcounter)
            {
                print("play llenar");
                FindObjectOfType<AudioManager>().Play("pis2", 1f);
                hasPlayPointcounter = true;

            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        print(other.transform.tag);

        if (other.transform.tag == "piso")
        {
            canPlayPiso = true;
            canPlayPismal = false;
            canPlayPointcounter = false;
            
            FindObjectOfType<AudioManager>().Stop("pis2");
            hasPlayPointcounter = false;
            FindObjectOfType<AudioManager>().Stop("pisborde");
            hasPlayPismal = false;
        }
        if (other.transform.tag == "pismal")
        {
            canPlayPiso = false;
            canPlayPismal = true;
            canPlayPointcounter = false;

            FindObjectOfType<AudioManager>().Stop("pis2");
            hasPlayPointcounter = false;
            FindObjectOfType<AudioManager>().Stop("pisSUELO");
            hasPlayPiso = false;
        }
        if (other.transform.tag == "pointcounter")
        {
            canPlayPiso = false;
            canPlayPismal = false;
            canPlayPointcounter = true;

            FindObjectOfType<AudioManager>().Stop("pisborde");
            hasPlayPismal = false;
            FindObjectOfType<AudioManager>().Stop("pisSUELO");
            hasPlayPiso = false;
        }
    }
}
