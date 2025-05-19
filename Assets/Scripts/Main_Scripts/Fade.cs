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
            color2.a -= 1 * Time.unscaledDeltaTime;
            _sr.color = color2;
        }

        if (dark)
        {
            color2.a += 3f * Time.unscaledDeltaTime;
            _sr.color = color2;
        }
    }

    public void DarkPlay()
    {

        dark = true;
        Debug.Log("¥Ÿ≈© πŸ≤Ò");
    }
}
