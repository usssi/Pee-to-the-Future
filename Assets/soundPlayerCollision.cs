using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundPlayerCollision : MonoBehaviour
{
    public string sonidoReproducir;
    public List<string> sonidosStop;
    private bool hasPlayed = false;

    public static bool PARTICLE_COLLISION = false;

    private void LateUpdate()
    {
        PARTICLE_COLLISION = false;
        hasPlayed = true;
        if (!PARTICLE_COLLISION)
        {
            FindObjectOfType<AudioManager>().Stop(sonidoReproducir);

        }
    }

    private void OnParticleCollision(GameObject other)
    {
        PARTICLE_COLLISION = true;
        if (!hasPlayed)
        {
            FindObjectOfType<AudioManager>().Play(sonidoReproducir, 1f);

            if (sonidosStop.Count > 0)
            {
                foreach (var item in sonidosStop)
                {
                    FindObjectOfType<AudioManager>().Stop(item);
                }
            }
        }
    }
}
