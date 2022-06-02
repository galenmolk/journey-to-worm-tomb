using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageFader : MonoBehaviour, IPointerClickHandler
{
    private static readonly int FadeAmount = Shader.PropertyToID("_FadeAmount");
    private static readonly int FadeWidth = Shader.PropertyToID("_FadeWidth");

    [SerializeField, Range(0, 1)] private float targetFadeWidth = 0.2f;
    [SerializeField, Min(0)] private float fadeDurationInSeconds = 1f;
    
    private Material material;
    private float fadeWidthDuration;

    [ContextMenu("Test")]
    public void Test()
    {
        StartCoroutine(Fade());
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Fade());
    }
    
    private void Awake()
    {
        material = GetComponent<Image>().material;
        fadeWidthDuration = fadeDurationInSeconds * targetFadeWidth;

        Initialize();
    }

    private void Initialize()
    {
        material.SetFloat(FadeAmount, 1f);
        material.SetFloat(FadeWidth, 0f);
    }

    private IEnumerator Fade()
    {
        Initialize();

        yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, targetFadeWidth, fadeWidthDuration));
        yield return StartCoroutine(LerpMaterialFloatProperty(FadeAmount, 0f, fadeDurationInSeconds));
        yield return StartCoroutine(LerpMaterialFloatProperty(FadeWidth, 0f, fadeWidthDuration));
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
