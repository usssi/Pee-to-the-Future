using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manejadordesencenas : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;

    }

    public void BotonCargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
