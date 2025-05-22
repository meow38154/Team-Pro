using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    RawImage _sr;
    float time;
    Color color2;
    [field: SerializeField] bool dark;

    private void Awake()
    {
        _sr = GetComponent<RawImage>();

        color2 = _sr.color;
        color2.a = 1f;
        _sr.color = color2;
    }

    private void Update()
    {
        if (color2.a > 0f && dark == false)
        {
            color2.a -= 0.5f * Time.unscaledDeltaTime;
            _sr.color = color2;
            StartCoroutine(Size());
        }
                

        if (dark)
        {
            color2.a += 3f * Time.unscaledDeltaTime;
            _sr.color = color2;
        }
    }

    IEnumerator Size()
    {
        yield return new WaitForSeconds(1);
        GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
    }

    public void DarkPlay()
    {

        dark = true;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        Debug.Log("¥Ÿ≈© πŸ≤Ò");
    }
}
