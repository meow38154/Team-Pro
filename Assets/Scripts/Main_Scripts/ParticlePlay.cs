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

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);

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
