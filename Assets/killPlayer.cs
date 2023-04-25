using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public bool killPlayerBool;
    public ControlGame gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        gamecontroller = FindObjectOfType<ControlGame>();
    }

    private void OnParticleCollision(GameObject other)
    {
        FindObjectOfType<AudioManager>().Play("laserKill", 1);

        killPlayerBool = true;
        gamecontroller.playerKill = killPlayerBool;
    }
}
