using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ReStartPlayerVector : MonoBehaviour
{
    [Header("범위 정하기")]
    [SerializeField] Vector2 ResetSizeOne;
    [SerializeField] Vector2 ResetSizeTwo;

    [Header("리셋 시 플레이어가 이동할 위치")]
    [SerializeField] Vector2 ResetPlayerPosition;

    [Header("건드리지 마시오")]
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _p;

    private void Awake()
    {
        _p = GameObject.Find("Player");
    }

    private void Update()
    {
        if (_p != null)
        {
            if (_p.transform.position.x >= ResetSizeOne.x && _p.transform.position.x <= ResetSizeTwo.x &&
                _p.transform.position.y <= ResetSizeOne.y && _p.transform.position.y >= ResetSizeTwo.y)
            {
                _player = GameObject.Find("Player");

                //if (GameManager.reset)
                {
                    //Debug.Log("ㅓㅑㄴㅇ햐ㅓㄹ히ㅓ아ㅣㅜㅠㅓ ㅜㅗㅇㄱ러ㅑ해ㅔㅐ우ㅗㅎ라네ㅔㅐ[]하ㅐㅓㅗㅠㅠㄴ다거ㅑㅣ애로ㅜㅏㅘㅑㅔㅐ더카[ㅣ");
                    _player.transform.position = ResetPlayerPosition;
                }
            }

            else
            {
                _player = null;
            }
        }
    }

    //커밋
}
