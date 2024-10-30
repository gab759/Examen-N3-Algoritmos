using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        fadeImage.gameObject.SetActive(true);
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = 255f;
            fadeImage.color = color;
        }
        StartCoroutine(FadeIn());
    }
    private IEnumerator FadeIn()
    {

        float elapsedTime = 0f;
        Color color = fadeImage.color;
        while (elapsedTime > fadeDuration)
        {
            elapsedTime -= Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
    }
}
