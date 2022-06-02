using System;
using System.Collections;
using MolkExtras;
using UnityEngine;

namespace WormTomb.UI
{
    public class TransitionFader : Singleton<TransitionFader>
    {
        private static readonly int FadeAmount = Shader.PropertyToID("_FadeAmount");
        private static readonly int FadeWidth = Shader.PropertyToID("_FadeWidth");

        [SerializeField, Range(0, 1)] private float targetFadeWidth = 0.03f;
        [SerializeField, Min(0)] private float fadeDurationInSeconds = 1f;
        [SerializeField] private float midFadeDelay = 0.5f;
        
        [SerializeField] private Material material;
        
        private float fadeWidthDuration;

        private bool isFading;
        
        public void Fade(Action midFadeAction)
        {
            if (isFading)
                return;
            
            isFading = true;
            StartCoroutine(FadeCoroutine(midFadeAction));
        }

        private IEnumerator FadeCoroutine(Action midFadeAction)
        {
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, targetFadeWidth, fadeWidthDuration));
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeAmount, 1f, fadeDurationInSeconds));
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, 0f, fadeWidthDuration));
            
            var halfMidFadeDelay = midFadeDelay * 0.5f;
            
            yield return YieldRegistry.WaitForSeconds(halfMidFadeDelay);
            
            midFadeAction?.Invoke();
            
            yield return YieldRegistry.WaitForSeconds(halfMidFadeDelay);
            
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, targetFadeWidth, fadeWidthDuration));
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeAmount, 0f, fadeDurationInSeconds));
            yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, 0f, fadeWidthDuration));
            isFading = false;
        }
        
        protected override void OnAwake()
        {
            base.OnAwake();
            fadeWidthDuration = fadeDurationInSeconds * targetFadeWidth;
            material.SetFloat(FadeAmount, 0f);
            material.SetFloat(FadeWidth, 0f);
        }
        
        private IEnumerator LerpMaterialFloatProperty(int id, float targetValue, float duration)
        {
            float time = 0f;
            float currentValue = material.GetFloat(id);
            while (time < duration)
            {
                material.SetFloat(id, Mathf.Lerp(currentValue, targetValue, time / duration));
                time += Time.deltaTime;
                yield return null;
            }
            material.SetFloat(id, targetValue);
        }
    }
}
