using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    [SerializeField] GameObject _summon1;

    [SerializeField] GameObject _summon2;

    [SerializeField] GameObject _summon3;

    [SerializeField] GameObject _summon4;

    [SerializeField] GameObject _stage;

    [SerializeField] GameObject _num1;

    [SerializeField] GameObject _num2;

    [SerializeField] GameObject _num3;

    [SerializeField] GameObject _num4;

    [SerializeField] GameObject _ZZA;

    [SerializeField] GameObject _player;

    [SerializeField] TextMeshPro _textdd;

    [SerializeField] int _endnum1;
    [SerializeField] int _endnum2;
    [SerializeField] int _endnum3;
    [SerializeField] int _endnum4;
    [SerializeField] int _speed;
    [SerializeField] int _Scene = 3;
    bool _numTF1;
    bool _numTF2;
    bool _numTF3;
    bool _numTF4;
    bool _numMove1;
    bool _numMove2;
    bool _numMove3;
    bool _numMove4;
    bool _zz;
    float time1 = 0;
    bool fff;
    float _uni;
    bool _uniTF;

    private void Start()
    {
        StaR();
        SettingManagerr.Instance.Copper += _endnum1;
        SettingManagerr.Instance.Iron += _endnum2;
        SettingManagerr.Instance.Gold += _endnum3;
        SettingManagerr.Instance.HapGold += _endnum4;
    }

    void StaR()
    {
            AudioManager.Instance.Clear();
            DownAnimation();
            RandomNumber1();
            RandomNumber2();
            RandomNumber3();
            RandomNumber4();
            StartCoroutine(TimeCool());
            StartCoroutine(TextSummon());
            StartCoroutine(Player());
            _zz = true;

    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(_Scene);
        }

        if (_numTF1)
        {
            _num1.GetComponent<TextMeshPro>().text = Random.Range(0, 9).ToString();
        }

        if (_numTF2)
        {
            _num2.GetComponent<TextMeshPro>().text = Random.Range(0, 9).ToString();
        }

        if (_numTF3)
        {
            _num3.GetComponent<TextMeshPro>().text = Random.Range(0, 9).ToString();
        }

        if (_numTF4)
        {
            _num4.GetComponent<TextMeshPro>().text = Random.Range(0, 9).ToString();
        }

        if (time1 >= 0.05f && fff)
        {
            time1 = 0;   
            AudioManager.Instance.PlayUICilck();
        }

        time1 += Time.deltaTime;

        if (_numMove1)
        {
            _summon1.transform.position += ((new Vector3(0, -0.5f, 0) - _summon1.transform.position) * Time.deltaTime * _speed);
        }

        if (_numMove2)
        {
            _summon2.transform.position += ((new Vector3(0, -2f, 0) - _summon2.transform.position) * Time.deltaTime * _speed);
        }

        if (_numMove3)
        {
            _summon3.transform.position += ((new Vector3(0, -3.5f, 0) - _summon3.transform.position) * Time.deltaTime * _speed);
        }

        if (_numMove4)
        {
            _summon4.transform.position += ((new Vector3(0f, -5f, 0) - _summon4.transform.position) * Time.deltaTime * _speed);
        }

        if (_zz)
        {
            _ZZA.transform.position += ((new Vector3(0f, 0f, 0) - _ZZA.transform.position) * Time.deltaTime * _speed);
        }

        if (_uniTF)
        {
            _uni += Time.deltaTime * 1;
            if (_uni > 1)
            {
                _uniTF = false;
            }
        }

        if (_uniTF == false)
        {
            _uni -= Time.deltaTime * 1;
            if (_uni < 0)
            {
                _uniTF = true;
            }
        }

        SetTextAlpha(_uni);
    }

    public void SetTextAlpha(float alpha)
    {
        Color color = _textdd.color;
        color.a = Mathf.Clamp01(alpha);
        _textdd.color = color;
    }

    IEnumerator Player()
    {
        yield return new WaitForSeconds(2.76f);
        _player.transform.localScale = new Vector3(10, 10, 10);

        yield return new WaitForSeconds(0.01f);
        _player.transform.localScale = new Vector3(9, 9, 9);
        yield return new WaitForSeconds(0.01f);
        _player.transform.localScale = new Vector3(8, 8, 8);
        yield return new WaitForSeconds(0.01f);
        _player.transform.localScale = new Vector3(7, 7, 7);
        yield return new WaitForSeconds(0.01f);
        _player.transform.localScale = new Vector3(6, 6, 6);
        yield return new WaitForSeconds(0.01f);
        _player.transform.localScale = new Vector3(5, 5, 5);
        yield return new WaitForSeconds(0.01f);

        yield return new WaitForSeconds(0.3f);
        _textdd.gameObject.SetActive(true);
        _uni = 0;
    }

    IEnumerator TextSummon()
    {
        yield return new WaitForSeconds(0.3f);
        _numMove1 = true;
        yield return new WaitForSeconds(0.6f);
        _numMove2 = true;
        yield return new WaitForSeconds(0.3f);
        _numMove3 = true;
        yield return new WaitForSeconds(0.2f);
        _numMove4 = true;
    }

    IEnumerator TimeCool()
    {
        fff = true;
        yield return new WaitForSeconds(2.5f);
        fff = false;
    }

    public void RandomNumber1()
    {
        StartCoroutine(Random1());
    }
    public void RandomNumber2()
    {
        StartCoroutine(Random2());
    }
    public void RandomNumber3()
    {
        StartCoroutine(Random3());
    }
    public void RandomNumber4()
    {
        StartCoroutine(Random4());
    }


    public void DownAnimation()
    {
        StartCoroutine(Down());
    }

    IEnumerator Random1()
    {
        _numTF1 = true;
        yield return new WaitForSeconds(1f);
        _numTF1 = false;
        _num1.GetComponent<TextMeshPro>().text = _endnum1.ToString();
    }

    IEnumerator Random2()
    {
        _numTF2 = true;
        yield return new WaitForSeconds(1.5f);
        _numTF2 = false;
        _num2.GetComponent<TextMeshPro>().text = _endnum2.ToString();
    }

    IEnumerator Random3()
    {
        _numTF3 = true;
        yield return new WaitForSeconds(2f);
        _numTF3 = false;
        _num3.GetComponent<TextMeshPro>().text = _endnum3.ToString();
    }

    IEnumerator Random4()
    {
        _numTF4 = true;
        yield return new WaitForSeconds(2.5f);
        _numTF4 = false;
        _num4.GetComponent<TextMeshPro>().text = _endnum4.ToString();
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(0.4f);
        _stage.SetActive(true);
        _stage.transform.localScale = new Vector3(1, 0.5f, 1);
        yield return new WaitForSeconds(0.02f);
        _stage.transform.localScale = new Vector3(1, 0.2f, 1);
        yield return new WaitForSeconds(0.02f);
        _stage.transform.localScale = new Vector3(1, 0.6f, 1);
        yield return new WaitForSeconds(0.02f);
        _stage.transform.localScale = new Vector3(1, 1f, 1);
    }
}
