using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class Light : MonoBehaviour
{
    Light2D _light;
    bool _updown;
    [FormerlySerializedAs("_min")] [SerializeField] private float min;
    [FormerlySerializedAs("_max")] [SerializeField] private float max;
    [FormerlySerializedAs("_power")] [SerializeField] private float power;

    private void Awake()
    {
        _light = GetComponent<Light2D>();
    }

    private void Update()
    {
        if (_light.falloffIntensity <= min)
            _updown = true;
        if (_light.falloffIntensity > max)
            _updown = false;

        if (_updown)
            _light.falloffIntensity += power * Time.deltaTime;
        if (_updown == false)
            _light.falloffIntensity -= power * Time.deltaTime;
    }
}
