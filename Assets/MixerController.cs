using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sfxSlider;
    public Slider musicSlider;

    private void Start()
    {
        if (sfxSlider != null)
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVol", 0);
        }
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVol", 0);
        }
    }

    public void SetSfxVolume(float value)
    {
        // Set the value of the "sfxVol" parameter in the mixer
        mixer.SetFloat("sfxVol", value);

        // Save the value to PlayerPrefs so it can be restored on subsequent launches
        PlayerPrefs.SetFloat("sfxVol", value);

        //print(value);
    }

    public void SetMusicVolume(float value)
    {
        // Set the value of the "musicVol" parameter in the mixer
        mixer.SetFloat("musicVol", value);

        // Save the value to PlayerPrefs so it can be restored on subsequent launches
        PlayerPrefs.SetFloat("musicVol", value);
    }
}
