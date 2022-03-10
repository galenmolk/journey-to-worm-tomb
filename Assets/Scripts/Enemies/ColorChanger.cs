using System;
using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class ColorChanger : MonoBehaviour
    {
        private SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            StartCoroutine(ChangeColors());
        }

        private IEnumerator ChangeColors()
        {
            while (gameObject.activeInHierarchy)
            {
                float r = UnityEngine.Random.Range(0f, 1f);
                float g = UnityEngine.Random.Range(0f, 1f);
                float b = UnityEngine.Random.Range(0f, 1f);
                float delay = UnityEngine.Random.Range(0.5f, 2f);
                Color color = new Color(r, g, b);
                sr.color = color;
                yield return YieldRegistry.WaitForSeconds(delay);
            }
        }
    }
}
