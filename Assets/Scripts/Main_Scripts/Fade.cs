using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fade : MonoBehaviour
{
    RawImage _sr;
    float time;
    Color color2;

    private void Awake()
    {
        _sr = GetComponent<RawImage>();

        // 시작할 때 완전 불투명하게 설정
        color2 = _sr.color;
        color2.a = 1f;
        _sr.color = color2;
    }

    private void Update()
    {
        // 시간이 지날수록 점점 투명하게 만들기
        if (color2.a > 0f)
        {
            color2.a -= 1f * Time.deltaTime;
            _sr.color = color2;
        }
    }
}
