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

        // ������ �� ���� �������ϰ� ����
        color2 = _sr.color;
        color2.a = 1f;
        _sr.color = color2;
    }

    private void Update()
    {
        // �ð��� �������� ���� �����ϰ� �����
        if (color2.a > 0f)
        {
            color2.a -= 1f * Time.deltaTime;
            _sr.color = color2;
        }
    }
}
