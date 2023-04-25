using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayOnStart : MonoBehaviour
{
    public string ambientPlay;
    public string musicPlay;

    public bool hasPlayerMusic;
    public bool hasPlayerambient;

    public AudioMixer mixer;



    // Start is called before the first frame update
    void Start()
    {
        hasPlayerMusic = false;
        hasPlayerambient = false;

        if (mixer != null)
        {
            mixer.SetFloat("musicCutoff", 22000);
            mixer.SetFloat("sfxCutoff", 22000);
        }
    }

    private void LateUpdate()
    {
        if (musicPlay != null)
        {
            if (!hasPlayerMusic)
            {
                FindObjectOfType<AudioManager>().Play(musicPlay, 1f);
                print("playMusic" + musicPlay);
                hasPlayerMusic = true;
            }
        }
        if (ambientPlay != null)
        {
            if (!hasPlayerambient)
            {
                FindObjectOfType<AudioManager>().Play(ambientPlay, 1f);
                print("playAmbience" + ambientPlay);
                hasPlayerambient = true;
            }
        }
    }

}
