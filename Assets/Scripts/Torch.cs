using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("Parameters")]
    public float MinIntesity = 0f; // ค่าความสว่างที่น้อยที่สุดที่ไฟทำได้
    public float MaxIntesity = 2f; // ค่าความสว่างที่มากที่สุดที่ไฟทำได้
    public float MinSpeed = 0.1f; // ค่าความเร็วในกว่าเปลี่ยนแปลงความสว่างที่น้อยที่สุดที่ไฟทำได้
    public float MaxSpeed = 0.2f; // ค่าความเร็วในกว่าเปลี่ยนแปลงความสว่างที่มากที่สุดที่ไฟทำได้

    Light _lightComponent; // ตัวแปร Light เพื่อใช้อ้างอิง Component Light ในคบเพลิง
    float _currentSpeed; // ค่าความเร็วในกว่าเปลี่ยนแปลงความสว่าง (เดี๋ยวจะสุ่มเอาจาก min, max)
    bool _isUp = false; // เช็คว่าไฟกำลังสว่างขึ้นหรือหรี่ลง (== false แสดงว่าไฟกำลังหรี่)

    void Start()
    {
        _lightComponent = transform.GetComponentInChildren<Light>();
        _lightComponent.intensity = Random.Range(MinIntesity, MaxIntesity); // สุ่มความสว่างของแสง
        RandomIntensitySpeed(); // สุ่มความเร็วในการเปลี่ยนความสว่าง
    }

    void Update()
    {
        // เพิ่มความส่ว่างไปเรื่อย ๆ จนถึง MaxIntesity
        if (_isUp)
        {
            if (_lightComponent.intensity < MaxIntesity)
                _lightComponent.intensity += _currentSpeed;
            // เปลี่ยนไปลดความสว่างและสุ่มความเร็วใหม่
            else
            {
                _isUp = false;
                RandomIntensitySpeed();
            }
        }
        // ลดความส่ว่างไปเรื่อย ๆ จนถึง MinIntesity
        else
        {
            if (_lightComponent.intensity > MinIntesity)
                _lightComponent.intensity -= _currentSpeed;
            // เปลี่ยนไปเพิ่มความสว่างและสุ่มความเร็วใหม่
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
