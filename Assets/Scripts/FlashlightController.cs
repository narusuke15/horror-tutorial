using UnityEngine;

/// <Summary>
/// Class ที่เอาไว้ใช้ควบคุมไฟฉาย
/// </Summary>
// [Tips] โดยทั่วไปเราจะใช้ชื่อ class ที่ขึ้นต้นและคั่นคำต่อไปด้วยตัวพิมพ์ใหญ่ เราเรียกวิธีการพิมพ์แบบนี้ว่า Pascal Casing
public class FlashlightController : MonoBehaviour
{
    [Header("Scene References")]
    public GameObject FlashlightGO; // ประกาศตัวแปรเพื่อ Reference ค่า GameObject ไฟฉายใน Scene

    [Header("Parameters")]
    public bool IsOn = true; // ตัวแปรเช็คว่าไฟฉายเปิดอยู่หรือไม่


    void Start()
    {
        FlashlightGO.SetActive(IsOn); // เปิด-ปิดไฟฉายตามค่า IsOn ด้วยการเปิด-ปิด GameObject ตอน scripts ทำงานครั้งแรก
    }

    void Update()
    {
        // เช็คทุกเฟรมว่าผู้เล่นกด 'F' หรือไม่
        // --- ถ้า condition ในวงเล็บเป็น 'true' จะทำงานในปีกา {} 
        // --- Input.GetKeyDown() จะส่งค่า bool มาให้เราว่าเรากดปุ่มนี้หรือไม่ ทำให้เราสามารถใช้เช็ค condition ใน if ได้เลย
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsOn = !IsOn; // เปลี่ยนค่า boolean เป็นค่าตรงข้ามของตัวเอง 
            // --- (สัญลักษณ์ '!' จะเปลี่ยนค่า จริง-เท็จ ให้เป็นตรงข้าม )
            FlashlightGO.SetActive(IsOn); // เปิด-ปิดไฟฉายตามค่า IsOn ด้วยการเปิด-ปิด GameObject
            // --- SetActive(bool) เป็น Function ของ Component GameObject ที่ใช้เปิด-ปิด Object ได้
        }
    }
}
