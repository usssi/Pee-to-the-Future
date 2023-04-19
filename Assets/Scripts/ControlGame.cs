using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEditor.Rendering;
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

    [Header("Canvas")]
    public Camera cameraLose;
    public Canvas canvasWin;
    public Canvas canvasLose;
    public Canvas canvasPause;
    public Canvas canvasPlay;

    [Header("Pastillas")]
    public int metaDisolver;

    private void Start()
    {
        canvasPlay.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        cameraLose.enabled = false;

        pointController.pointsToWin = pointsToWin;

        pastillasControl.metaDisolver = metaDisolver;
        pastillasControl.metaDisolverTexto = metaDisolver;

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

        if (CondicionDeVictoria == "bugs")
        {
            if (pastillasControl.pastillasDisueltas >= metaDisolver)//cuando la puntuacion llega a puntos para ganar
            {                
                Invoke("PantallaGanada", 1.5f);
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
        cameraLose.enabled = true;
        canvasPlay.enabled = false;

    }

    void PantallaPerdida()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        canvasLose.enabled = true;
        cameraLose.enabled = true;
        canvasPlay.enabled = false;

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
                cameraLose.enabled = false;

                canvasPlay.enabled = true;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                canvasPause.enabled = true;
                cameraLose.enabled = true;

                canvasPlay.enabled = false;
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

}