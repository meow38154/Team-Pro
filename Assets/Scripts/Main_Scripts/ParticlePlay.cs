using UnityEngine;
using System.Collections;

public class ParticlePlay : MonoBehaviour
{
    public void OnEnable()
    {
        Debug.Log("»£√‚");
        StartCoroutine(Destoryy());
        GetComponent<ParticleSystem>().Play();
    }

    IEnumerator Destoryy()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds(GetComponent<ParticleSystem>().startLifetime);
        Debug.Log("∆„");
        Destroy(gameObject);
    }
}
