using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{
    Light2D _light;
    bool _updown;
    [SerializeField] float _min, _max;
    [SerializeField] float _power;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (_light.falloffIntensity <= _min)
            _updown = true;
        if (_light.falloffIntensity > _max)
            _updown = false;

        if (_updown)
            _light.falloffIntensity += _power * Time.deltaTime;
        if (_updown == false)
            _light.falloffIntensity -= _power * Time.deltaTime;
    }
}
