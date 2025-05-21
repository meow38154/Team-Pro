using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Lws_VidioPlay : MonoBehaviour
{
    [SerializeField] GameObject VidioPlayer;
    [SerializeField] GameObject VidioText;
    bool b = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (b) StartCoroutine(a());
    }


    IEnumerator a()
    {
        b = false;
        VidioPlayer.SetActive(true);
        VidioText.SetActive(true);
        yield return new WaitForSeconds(6);
        VidioText.SetActive(false);
        yield return new WaitForSeconds(26);
        VidioPlayer.SetActive(false);
        yield return new WaitForSeconds(2);
        b = true;
    }
}
