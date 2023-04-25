using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class manejadordesencenas : MonoBehaviour
{
    public AudioMixer mixer;

    public void BotonCargarEscena(string escena)
    {
        FindObjectOfType<AudioManager>().Play("button2", 1f);

        SceneManager.LoadScene(escena);
    }
    public void BotonRecargarMismaEscena()
    {
        FindObjectOfType<AudioManager>().Play("button2", 1f);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void SalirDelJuego()
    {
        FindObjectOfType<AudioManager>().Play("button2", 1f);

        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void SalirAlMenu()
    {
        if (mixer != null)
        {
            mixer.SetFloat("musicCutoff", 22000);
            mixer.SetFloat("sfxCutoff", 22000);
        }

        SceneManager.LoadScene("MenuInicio");
    }
    public void HideCanvasButton(Canvas canvastohide)
    {
        if (canvastohide.enabled == true)
        {
            canvastohide.enabled = false;
        }
        else
        {
            canvastohide.enabled = true;
        }
    }
}
