using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    private Image image;
    private float fadeTimer = 0f;
    private bool isFading = false;
    private bool fadeIn = false;

    void Awake()
    {
        image = GetComponent<Image>();
        GetComponent<Image>().enabled = false;
        StartFadeOut();
    }

    public void StartFadeOut()
    {
        fadeTimer = 0f;
        isFading = true;
        fadeIn = false;
    }

    public void StartFadeIn()
    {
        fadeTimer = 0f;
        isFading = true;
        fadeIn = true;
        GetComponent<Image>().enabled = true;
    }

    void Update()
    {
        if (!isFading) return;

        fadeTimer += Time.unscaledDeltaTime;
        float t = Mathf.Clamp01(fadeTimer / fadeDuration);

        Color color = image.color;
        color.a = fadeIn ? Mathf.Lerp(0f, 1f, t) : Mathf.Lerp(1f, 0f, t);
        image.color = color;

        if (t >= 1f)
        {
            isFading = false;
            if (color.a == 255)
            {
                GetComponent<Image>().enabled = false;
            }
        }
    }
}
