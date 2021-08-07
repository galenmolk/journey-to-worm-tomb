using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Material background = null;
    private readonly int scrollSpeed = Shader.PropertyToID("_ScrollSpeed");

    private void Update()
    {
        background.SetFloat(scrollSpeed, Player.Instance.RunSpeed);
    }
}
