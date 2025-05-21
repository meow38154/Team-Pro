using System.Collections;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    [SerializeField] GameObject hd;
    bool b = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(b)
            StartCoroutine(HdCoroutine());
    }

    IEnumerator HdCoroutine()
    {
        b = false;
        hd.SetActive(true);
        yield return new WaitForSeconds(32);
        hd.SetActive(false);
        yield return new WaitForSeconds(2);
        b = true;
    }
}
