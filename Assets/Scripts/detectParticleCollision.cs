using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectParticleCollision : MonoBehaviour
{
    public float puntosContados;
    public float pointMultiplier = 1;

    public GameObject particulaSuciedad;

    private void OnParticleCollision(GameObject other)
    {
        print("pis choca con diana");
        puntosContados += 1 * Time.deltaTime * pointMultiplier;

        var coll = particulaSuciedad.GetComponent<ParticleSystem>().collision;
        coll.enabled = false;
    }

}
