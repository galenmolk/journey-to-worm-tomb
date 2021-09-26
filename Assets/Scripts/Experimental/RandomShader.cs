using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShader : MonoBehaviour
{
    [SerializeField] private Material material;

    int color1 = Shader.PropertyToID("_Color1");
    int color2 = Shader.PropertyToID("_Color2");
    int color3 = Shader.PropertyToID("_Color3");
    int color4 = Shader.PropertyToID("_Color4");

    private int counter = 0;

    private void FixedUpdate()
    {
        if (counter % 50 == 0)
        {
            material.SetVector(color1, RandomVector());
            material.SetVector(color2, RandomVector());
            material.SetVector(color3, RandomVector());
            material.SetVector(color4, RandomVector());

        }

        counter++;
    }

    private Vector4 RandomVector()
    {
        return new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
