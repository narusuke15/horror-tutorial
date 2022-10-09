using UnityEngine;
using UnityEngine.UI;

/// <Summary>
/// Class ที่เอาไว้ใช้ควบคุมไฟฉาย
/// </Summary>
// [Tips] โดยทั่วไปเราจะใช้ชื่อ class ที่ขึ้นต้นและคั่นคำต่อไปด้วยตัวพิมพ์ใหญ่ เราเรียกวิธีการพิมพ์แบบนี้ว่า Pascal Casing
public class FlashlightController : MonoBehaviour
{
    [Header("References")]
    public FlashlightPRO Flashlight; // ประกาศตัวแปรเพื่อ Reference ค่า FlashlightPRO ไฟฉายใน Scene
    public Image BatteryBar;
    [Header("Parameters")]
    public float BatteryDrain = 1f;

    [SerializeField] bool _isOn;
    [SerializeField] float _battery = 1f;

    void Update()
    {
        // เช็คทุกเฟรมว่าผู้เล่นกด 'F' หรือไม่
        // --- ถ้า condition ในวงเล็บเป็น 'true' จะทำงานในปีกา {} 
        // --- Input.GetKeyDown() จะส่งค่า bool มาให้เราว่าเรากดปุ่มนี้หรือไม่ ทำให้เราสามารถใช้เช็ค condition ใน if ได้เลย
        if (Input.GetKeyDown(KeyCode.F) && _battery > 0)
        {
            Flashlight.Switch(); // เปิด-ปิดไฟฉาย
            _isOn = Flashlight.IsFlashlightOn();
        }

        if (_isOn && _battery > 0)
        {
            _battery -= BatteryDrain * Time.deltaTime;
            BatteryBar.fillAmount = _battery;
            if (_battery <= 0)
            {
                _battery = 0;
                Flashlight.Switch();
                _isOn = false;
            }
        }
    }
}
