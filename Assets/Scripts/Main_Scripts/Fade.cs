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
        // �ڵ� ���̵��� ����
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
        // �������� ������ ���� ����
        while (_sr.color.a > 0f)
        {
            color2.a -= 0.5f * Time.unscaledDeltaTime;
            _sr.color = color2;
            yield return null;
        }

        color2.a = 0f;
        _sr.color = color2;

        // ���̵��� �Ϸ� �� �̹��� ����
        GetComponent<RectTransform>().sizeDelta = Vector2.zero;
    }

    IEnumerator FadeOut()
    {
        // ũ�� ���� (Ȥ�ö� �۾���������)
        GetComponent<RectTransform>().sizeDelta = new Vector2(5000, 5000);

        // ������ �˰� �� ������ ���� ����
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
