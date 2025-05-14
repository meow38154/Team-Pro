using UnityEngine;
using System.Collections;

public class ParticlePlay : MonoBehaviour
{
    [SerializeField] Color _color;
    [SerializeField] Blocks _blockParents;

    private void OnEnable()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<ParticleSystem>().startColor = _blockParents._coler;
        ParticleStart();
    }

    public void ParticleStart()
    {
        StartCoroutine(ParticleExplosionPlay());
    }

    IEnumerator ParticleExplosionPlay()
    {
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
