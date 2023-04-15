using UnityEngine;
using System.Collections;

public class drunk : MonoBehaviour
{
    public Material material;
    public float intensity = 1.0f;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_Intensity", intensity);
        Graphics.Blit(source, destination, material);
    }


}