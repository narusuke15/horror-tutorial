using UnityEngine;

/// <summary>
/// Class ควบคุม Player
/// </summary>
public class Player : MonoBehaviour
{
    [Header("References")]
    public Transform PlayerTransform; // อ้างอิงข้อมูลตำแหน่งจาก component transform

    [Header("Debug (เอาไว้แสดงผลอย่างเดียว)")]
    public float DistanceFromTarget; // แสดงระยะห่างของผู้เล่นกับวัตถุที่ชน
    public string HitName; // แสดงชื่อของวัตถุทีชน

    void Update()
    {
        RaycastHit hit; // ประกาศตัวแปร RaycastHit เพื่อเอาไว้ส่งไปรับค่าการเช็คชนจาก Physics.Raycast(...) ได้
        // bool Physics.Raycast(...) เอาไว้ยิงเส้นไปเช็คว่าเส้นนี้ไปชนกับ GameObject ที่มี Collider หรือไม่ และส่งค่า true, false กลับมา
        // --- [p1] PlayerTransform.position >> แทนจุดเริ่มต้นของเส้นที่จะยิง
        // --- [p2] PlayerTransform.TransformDirection(Vector3.forward)​ >> แทนทิศทางของเส้นที่จะยิง
        // --- [p3] out hit >> ถ้ามีการชนจะส่งข้อมูลของวัตถุที่ชนกลับมาให้ตัวแปร hit สำหรับเอามาใช้งานต่อได้
        if (Physics.Raycast(PlayerTransform.position, PlayerTransform.TransformDirection(Vector3.forward), out hit))
        {
            DistanceFromTarget = hit.distance; // แสดงระยะห่างของผู้เล่นกับวัตถุที่ชน
            HitName = hit.collider.name; // แสดงชื่อของวัตถุทีชน
        }
        // ถ้า Raycast ไม่โดนอะไรเลยให้แสดงค่าตามด้านล่าง (เอาไว้ช่วย Debug)
        else
        {
            DistanceFromTarget = 0;
            HitName = "none";
        }
    }
}
