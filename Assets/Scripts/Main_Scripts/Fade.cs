using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    RawImage _sr;
    Color color2;
    Coroutine fadeCoroutine;
    [field: SerializeField] bool dark;

    private void Awake()
    {
        _sr = GetComponent<RawImage>();
        color2 = _sr.color;
        color2.a = 1f;
        _sr.color = color2;
    }

    private void Start()
    {
        // 자동 페이드인 시작
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeIn());
    }

    public void DarkPlay()
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        fadeCoroutine = StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        // 투명해질 때까지 알파 감소
        while (_sr.color.a > 0f)
        {
            color2.a -= 0.5f * Time.unscaledDeltaTime;
            _sr.color = color2;
            yield return null;
        }

        color2.a = 0f;
        _sr.color = color2;

        // 페이드인 완료 후 이미지 제거
        GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }

    IEnumerator FadeOut()
    {
        // 크기 복원 (혹시라도 작아져있으면)
        GetComponent<RectTransform>().sizeDelta = new Vector2(5000, 5000);

        // 완전히 검게 될 때까지 알파 증가
        while (_sr.color.a < 1f)
        {
            color2.a += 3f * Time.unscaledDeltaTime;
            _sr.color = color2;
            yield return null;
        }

        color2.a = 1f;
        _sr.color = color2;
    }
}
