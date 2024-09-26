using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class fadein : MonoBehaviour
{
    public Image fadeImage; // Drag your Image here in the inspector
    public float fadeSpeed = 1f; // Speed of fade in/out
    private bool isFading = false;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut(sceneName));
        }
    }

    IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeSpeed;
            SetImageAlpha(alpha);
            yield return null;
        }
        SetImageAlpha(0);
    }

    IEnumerator FadeOut(string sceneName)
    {
        isFading = true;
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeSpeed;
            SetImageAlpha(alpha);
            yield return null;
        }
        SetImageAlpha(1);
        SceneManager.LoadScene(sceneName);
    }

    void SetImageAlpha(float alpha)
    {
        Color color = fadeImage.color;
        color.a = alpha;
        fadeImage.color = color;
    }
}