using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{

    public Points pointController;
    public pissController pisController;
    public IntensityController intensityController;
    public ControladorDePastillas pastillasControl;

    public Transform inodoro;
    public bool moveInodoro;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;


    private float t = 0.0f;

    public int pointsToWin;
    public int pastillasToWin;


    public float velocidadBajadaDeBarraDePipi;

    public GameObject pissWater;
    public float minPissWaterY;
    public float maxPissWaterY;

    public string CondicionDeVictoria;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        pointController.pointsToWin = pointsToWin;
        pastillasControl.metaDisolver = pastillasToWin;

        startPosition += inodoro.position;
        endPosition += inodoro.position;

    }

    private void Update()
    {
        pisController.MakePisGoDown(velocidadBajadaDeBarraDePipi);

        DeterminarCondicionDeVictoria();

        if (moveInodoro)
        {
            MakeInodoroMove();
        }
    }

    void DeterminarCondicionDeVictoria()
    {
        if (CondicionDeVictoria == "llenarInodoro")
        {
            MakePissWaterGoAccordingToPoints();

            if (pointController.points >= pointsToWin)//cuando la puntuacion llega a puntos para ganar
            {
                Debug.Log("GANASTE!");
                PantallaGanada();
            }
            else if (pisController.Progress <= 0)//cuando se te acaba el pis
            {
                Debug.Log("PERDISTE!");
                PantallaPerdida();
            }
        }
        if (CondicionDeVictoria == "pastillas")
        {
            if (pastillasControl.pastillasDisueltas >= pastillasToWin)//cuando disolves las pastillas
            {
                Debug.Log("GANASTE!");
                PantallaGanada();
            }
            else if (pisController.Progress <= 0)//cuando se te acaba el pis
            {
                Debug.Log("PERDISTE!");
                PantallaPerdida();
            }

        }
    }

    void PantallaGanada()
    {
        SceneManager.LoadScene("winScene");
    }

    void PantallaPerdida()
    {
        SceneManager.LoadScene("loseScene");
    }

    void MakePissWaterGoAccordingToPoints()
    {
        float t = pointController.points / 100f;
        float newY = Mathf.Lerp(minPissWaterY, maxPissWaterY, t);
        Vector3 pos = pissWater.transform.position;
        pos.y = newY;
        pissWater.transform.position = pos;
    }

    void MakeInodoroMove()
    {
        t += Time.deltaTime * speed;
        inodoro.transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(t, 1.0f));
    }
}