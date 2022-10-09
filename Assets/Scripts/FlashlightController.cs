using UnityEngine;

/// <Summary>
/// Class ที่เอาไว้ใช้ควบคุมไฟฉาย
/// </Summary>
// [Tips] โดยทั่วไปเราจะใช้ชื่อ class ที่ขึ้นต้นและคั่นคำต่อไปด้วยตัวพิมพ์ใหญ่ เราเรียกวิธีการพิมพ์แบบนี้ว่า Pascal Casing
public class FlashlightController : MonoBehaviour
{
    [Header("References")]
    public FlashlightPRO Flashlight; // ประกาศตัวแปรเพื่อ Reference ค่า FlashlightPRO ไฟฉายใน Scene

    void Update()
    {
        // เช็คทุกเฟรมว่าผู้เล่นกด 'F' หรือไม่
        // --- ถ้า condition ในวงเล็บเป็น 'true' จะทำงานในปีกา {} 
        // --- Input.GetKeyDown() จะส่งค่า bool มาให้เราว่าเรากดปุ่มนี้หรือไม่ ทำให้เราสามารถใช้เช็ค condition ใน if ได้เลย
        if (Input.GetKeyDown(KeyCode.F))
        {
            Flashlight.Switch(); // เปิด-ปิดไฟฉาย
        }
    }
}
