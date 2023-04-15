using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pisodetectacollisiondeparticulayseensicua : MonoBehaviour
{
    public GameObject particulaSuciedad;

    private void OnParticleCollision(GameObject other)
    {        
        var coll = particulaSuciedad.GetComponent<ParticleSystem>().collision;
        coll.enabled = true;
    }
}
