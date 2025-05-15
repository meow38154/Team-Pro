using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ReStartPlayerVector : MonoBehaviour
{
    [Header("���� ���ϱ�")]
    [SerializeField] Vector2 ResetSizeOne;
    [SerializeField] Vector2 ResetSizeTwo;

    [Header("���� �� �÷��̾ �̵��� ��ġ")]
    [SerializeField] Vector2 ResetPlayerPosition;

    [Header("�ǵ帮�� ���ÿ�")]
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
                    //Debug.Log("�ä�������ä����þƤӤ̤Ф� �̤Ǥ��������ؤĤ���Ǥ���פĤ�[]�Ϥ��äǤФФ��ٰŤ��ӾַΤ̤��Ȥ��Ĥ���ī[��");
                    _player.transform.position = ResetPlayerPosition;
                }
            }

            else
            {
                _player = null;
            }
        }
    }

    //Ŀ��
}
