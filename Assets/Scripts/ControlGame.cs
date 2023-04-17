using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlGame : MonoBehaviour
{
    [Header("Referencias")]
    public Points pointController;
    public PeeControllerDefinitivo peeController;
    public ControladorDePastillas pastillasControl;

    [Header("General Game Stuff")]
    public string CondicionDeVictoria;
    public bool canLose;
    public bool togglePeeParticles;
    public bool togglePeeNoise;
    public int pointsToWin;

    [Header("Agua De Inodoro Pee")]
    public GameObject pissWater;
    public float minPissWaterY;
    public float maxPissWaterY;

    [Header("Move Inodoro")]
    public bool moveInodoro;
    public Transform inodoro;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 1.0f;
    private float t = 0.0f;

    [Header("Canvas")]
    public Camera cameraResult;
    public Canvas canvasWin;
    public Canvas canvasLose;
    public Canvas canvasPause;

    private void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cameraResult.enabled = false;

        pointController.pointsToWin = pointsToWin;

        if (moveInodoro)
        {
            startPosition += inodoro.position;
            endPosition += inodoro.position;
        }
    }

    private void Update()
    {
        if (canLose)
        {
            DeterminarCondicionDeVictoria();
            peeController.MakePanzaGoDown();
        }
        else
        {
            MakePissWaterGoAccordingToPoints();
        }

        if (moveInodoro)
        {
            MakeInodoroMove();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePantallaPausa();
        }

        peeController.ToggleParticles(togglePeeParticles);
        peeController.TogglePeeNoise(togglePeeNoise);
    }

    void DeterminarCondicionDeVictoria()
    {
        if (CondicionDeVictoria == "llenarInodoro")
        {
            MakePissWaterGoAccordingToPoints();

            if (pointController.points >= pointsToWin)//cuando la puntuacion llega a puntos para ganar
            {
                PantallaGanada();
            }
            else if (peeController.capacidadPee <= 0)//cuando se te acaba el pis
            {
                PantallaPerdida();
            }
        }

    }

    #region region UI
    void PantallaGanada()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        canvasWin.enabled = true;
        cameraResult.enabled = true;
    }

    void PantallaPerdida()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        canvasLose.enabled = true;
        cameraResult.enabled = true;
    }

    public void TogglePantallaPausa()
    {
        if (canvasLose.enabled == false && canvasWin.enabled == false)
        {
            if (canvasPause.enabled == true)
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                canvasPause.enabled = false;
                cameraResult.enabled = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                canvasPause.enabled = true;
                cameraResult.enabled = true;
            }
        }
    }
    #endregion

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