using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ControladorDePastillas : MonoBehaviour
{
    public List<DisolvedorDePastilla> listaDisolvedores;
    public int pastillasDisueltas;
    [HideInInspector] public int metaDisolver;
    [HideInInspector] public int metaDisolverTexto;

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
                metaDisolverTexto--;
                AnimateTextColorWhenKillBug();
            }
        }

        if (textoPastillas != null)
        {
            textoPastillas.text = "kill " + metaDisolverTexto + " bugs";
            
            if (metaDisolverTexto <= 0)
            {
                textoPastillas.text = "you win!";
                TextColorAnimation();
            }
        }
    }

    void AnimateTextColorWhenKillBug()
    {
        TextToGreen();
        Invoke("TextToRED", .5f);
    }

    void TextColorAnimation()
    {
        TextToGreen();
        Invoke("TextToWhite", .5f);
        Invoke("TextToGreen", 1.5f);
        Invoke("TextToWhite", 2f);
        Invoke("TextToGreen", 2.5f);

    }
    void TextToRED()
    {
        textoPastillas.color = Color.red;
    }
    void TextToWhite()
    {
        textoPastillas.color = Color.white;
    }
    void TextToGreen()
    {
        textoPastillas.color = Color.green;
    }
}
