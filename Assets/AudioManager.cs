using UnityEngine.Audio;
using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public string playOnAwakeAmbient;
    public string playOnAwakeMusic;


    public Sound[] sounds;
    public Sound[] playList;

    /*
    FindObjectOfType<AudioManager>().Play("",1f);
    */


    void Awake()
    {
        foreach (Sound s in sounds)
        {
            if (!s.name.Contains("var"))
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.outputAudioMixerGroup = s.output;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;

                s.source.loop = s.loop;
                s.source.mute = s.mute;
            }
        }

        //print("audio manager woke up");
        FindObjectOfType<AudioManager>().Play(playOnAwakeMusic, 1f);
        FindObjectOfType<AudioManager>().Play(playOnAwakeAmbient, 1f);

        DontDestroyOnLoad(this.gameObject);
    }

    public void Play(string name, float pitchTone)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitchTone;

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

    public void PlayVar(string name, float pitchTone)
    {
        int i = 0;
        foreach (Sound ss in sounds)
        {
            if (ss.name.Contains(name))
            {
                playList[i] = ss;
                i++;
            }
        }

        int y;
        y = Random.Range(0, i);

        Sound sv = Array.Find(sounds, sound => sound.name == name);
        sv.source.clip = playList[y].clip;
        sv.source.pitch = pitchTone;

        if (sv == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        sv.source.Play();

        //print("audio manager played" + name);

    }

    public void OnButtonSelect()
    {
        FindObjectOfType<AudioManager>().Play("buttonSelect", 1f);

    }
}
