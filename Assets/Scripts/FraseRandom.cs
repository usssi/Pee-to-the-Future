using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


public class FraseRandom : MonoBehaviour
{
    public TextMeshProUGUI miTexto; // Referencia al componente TextMeshProUGUI en la UI
    public string[] frases; // Arreglo de frases para mostrar en el TextMeshPro


    void Start()
    {
        // Mezclar aleatoriamente el arreglo de frases
        ShuffleArray(frases);

        // Obtener una frase aleatoria del arreglo y asignarla al componente TextMeshPro
        string fraseAleatoria = frases[0];
        miTexto.text = fraseAleatoria;
    }
    string[] fraseAleatoria = new string[]
    { "El que para mear tiene prisa, termina por mearse la camisa",
            "Mear claro y recio, deja al médico por necio ",
            "No temas tirarte un pedo mientras meas, nunca hay lluvia sin truenos" };

    // Método para mezclar aleatoriamente un arreglo
    void ShuffleArray<T>(T[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}




