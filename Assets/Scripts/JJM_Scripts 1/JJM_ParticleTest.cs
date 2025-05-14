using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class JJM_ParticleTest : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    private void Awake()
    {
        _particle.Stop();
        _particle.startColor = Color.yellow;
    }

    public void ParticleStart()
    {
        StartCoroutine(ParticleExplosion());
    }

    IEnumerator ParticleExplosion()
    {
        _particle.Play();
        yield return new WaitForSeconds(0.05f);
        _particle.Stop();
    }
}
