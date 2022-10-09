using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("Parameters")]
    public float MinIntesity = 0f;
    public float MaxIntesity = 2f;
    public float MinSpeed = 0.1f;
    public float MaxSpeed = 0.2f;

    float _currentSpeed;
    Light _lightComponent;
    bool _isUp = false;

    void Start()
    {
        _lightComponent = transform.GetComponentInChildren<Light>();
        _lightComponent.intensity = Random.Range(MinIntesity, MaxIntesity); // สุ่มความสว่างของแสง
        RandomIntensitySpeed();
    }

    void Update()
    {
        if (_isUp)
        {
            if (_lightComponent.intensity < MaxIntesity)
                _lightComponent.intensity += _currentSpeed;
            else
            {
                _isUp = false;
                RandomIntensitySpeed();
            }
        }
        else
        {
            if (_lightComponent.intensity > MinIntesity)
                _lightComponent.intensity -= _currentSpeed;
            else
            {
                _isUp = true;
                RandomIntensitySpeed();
            }
        }
    }

    void RandomIntensitySpeed()
    {
        _currentSpeed = Random.Range(MinSpeed, MaxSpeed);
    }
}
