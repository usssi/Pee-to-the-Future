using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CleanSTart : MonoBehaviour
{
    public AudioMixer mixer;
    private bool cleaned;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in FindObjectOfType<AudioManager>().sounds)
        {
            FindObjectOfType<AudioManager>().Stop(item.name);
        }

        mixer.SetFloat("musicCutoff", 22000);
        mixer.SetFloat("sfxCutoff", 22000);
    }

    private void Start()
    {
        FindObjectOfType<AudioManager>().Stop("pisborde");
        FindObjectOfType<AudioManager>().Stop("pisSUELO");
        FindObjectOfType<AudioManager>().Stop("pis2");
    }

    private void LateUpdate()
    {
        if (!cleaned)
        {
            mixer.SetFloat("musicCutoff", 22000);
            mixer.SetFloat("sfxCutoff", 22000);
            cleaned = true;
        }
    }
}
