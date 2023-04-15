using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{

    public Points pointController;
    public pissController pisController;
    public IntensityController intensityController;

    public int pointsToWin;
    public float pointMultiplier;

    public float velocidadBajadaDePipi;

    private void Start()
    {
        Cursor.visible = false;

        pointController.pointsToWin = pointsToWin;
        pointController.pointMultiplier = pointMultiplier;
    }

    private void Update()
    {
        pisController.MakePisGoDown(velocidadBajadaDePipi);

        PantallaGanada();
        PantallaPerdida();
    }

    void PantallaGanada()
    {
        if (pointController.points >= pointsToWin)
        {
            Debug.Log("GANASTE!");
            SceneManager.LoadScene("winScene");
        }
    }

    void PantallaPerdida()
    {
        if (pisController.Progress <= 0)
        {
            Debug.Log("PERDISTE!");
            SceneManager.LoadScene("loseScene");
        }
    }
}
