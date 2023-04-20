using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manejadordesencenas : MonoBehaviour
{

    public void BotonCargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void BotonRecargarMismaEscena()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void SalirDelJuego()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
