using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    [Header("References")]
    public FlashlightPRO Flashlight; // ประกาศตัวแปรเพื่อ Reference ค่า FlashlightPRO ไฟฉายใน Scene
    public Image BatteryBar;

    [Header("Parameters")]
    public float BatteryDrain = 1f;

    [Header("Debug")]
    [SerializeField] bool _isOn;
    [SerializeField] float _battery = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _battery > 0)
        {
            Flashlight.Switch(); // เปิด-ปิดไฟฉาย
            _isOn = Flashlight.IsFlashlightOn();
        }

        if (_isOn && _battery > 0)
        {
            _battery -= BatteryDrain * Time.deltaTime;
            BatteryBar.fillAmount = _battery;
            Flashlight.ChangeIntensity(_battery * 100f);
            if (_battery <= 0)
            {
                _battery = 0;
                Flashlight.Switch();
                _isOn = false;
            }
        }
    }

    public void AddBattery(float amount)
    {
        _battery += amount;
        if (_battery > 1)
            _battery = 1;
        BatteryBar.fillAmount = _battery;
    }
}
