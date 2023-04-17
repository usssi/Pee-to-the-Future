using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ControladorDePastillas : MonoBehaviour
{
    public List<DisolvedorDePastilla> listaDisolvedores;
    public int pastillasDisueltas;
    [HideInInspector] public int metaDisolver;
    public float disolveMultiplier;


    public TextMeshProUGUI textoPastillas;


    private void Start()
    {
        DisolvedorDePastilla[] disolvedores = FindObjectsOfType<DisolvedorDePastilla>();
        listaDisolvedores = new List<DisolvedorDePastilla>(disolvedores);
    }

    private void Update()
    {
        foreach (var pastilla in listaDisolvedores.ToList())
        {
            if (pastilla.isDisolved)
            {
                pastillasDisueltas++;
                listaDisolvedores.Remove(pastilla);
            }
        }

        //textoPastillas.text = "Disueltas: " + pastillasDisueltas.ToString("0") + "/" + metaDisolver;

    }
}
