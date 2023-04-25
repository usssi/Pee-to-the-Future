using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmusiconplay : MonoBehaviour
{
    public string musicalevelstopper;
    public string ambientlevelstopper;

    public void stopmusic()
    {
        if (musicalevelstopper != null)
        {
            FindObjectOfType<AudioManager>().Stop(musicalevelstopper);

        }
        if (ambientlevelstopper != null)
        {
            FindObjectOfType<AudioManager>().Stop(ambientlevelstopper);


        }
    }
}
