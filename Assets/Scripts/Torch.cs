using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("Parameters")]
    public float MinIntesity = 0f;
    public float MaxIntesity = 2f;
    public float Speed = 0.1f;

    Light _lightComponent;
    bool _isUp = false;

    void Start()
    {
        _lightComponent = transform.GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (_isUp)
        {
            if (_lightComponent.intensity < MaxIntesity)
                _lightComponent.intensity += Speed;
            else
            {
                _isUp = false;
                Debug.Log("Down");
            }
        }
        else
        {
            if (_lightComponent.intensity > MinIntesity)
                _lightComponent.intensity -= Speed;
            else
            {
                _isUp = true;
                Debug.Log("Up");
            }
        }
    }
}
