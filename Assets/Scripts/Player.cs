using UnityEngine;

/// <summary>
/// Class ควบคุมการทำงานของ Player
/// </summary>
public class Player : MonoBehaviour
{
    [Header("References")]
    public Transform PlayerTransform; // อ้างอิงข้อมูลตำแหน่งจาก component transform
    public ActionUICanvas ActionUICanvasComponent;

    [Header("Parameters")]
    public float InteractionRange = 2f; // ระยะที่ผู้เล่นสามสารถ interact ได้

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
        if (Physics.Raycast(PlayerTransform.position, PlayerTransform.TransformDirection(Vector3.forward), out hit, InteractionRange))
        {
            DistanceFromTarget = hit.distance; // แสดงระยะห่างของผู้เล่นกับวัตถุที่ชน
            HitName = hit.collider.name; // แสดงชื่อของวัตถุทีชน
            Debug.DrawRay(PlayerTransform.position, PlayerTransform.TransformDirection(Vector3.forward).normalized * InteractionRange, Color.green);
            // check interaction
            if (hit.collider.tag == "Interactable")
            {
                Door door = hit.transform.GetComponent<Door>(); // ดึง reference ของ component Door จากวันถุทีี่ยิง Ray ชน
                string interactionText = door.GetInteractionText(); // รับข้อมูล ActionText จากประตู
                ActionUICanvasComponent.ShowInteractionUI(interactionText); // แสดง ActionUI ของประตู
                // สั่งให้เปิดปิดประตูเมื่อกดปุ่ม 'e'
                if (Input.GetKeyDown(KeyCode.E))
                    door.Interact();
            }
            else
                ActionUICanvasComponent.HideCanvas(); // พยายามปิด ActionUI Canvas ถ้าวัตถุที่ชนไม่ใช่ interactable
        }
        // ถ้า Raycast ไม่โดนอะไรเลยให้แสดงค่าตามด้านล่าง (เอาไว้ช่วย Debug)
        else
        {
            DistanceFromTarget = 0;
            HitName = "none";
            Debug.DrawRay(PlayerTransform.position, PlayerTransform.TransformDirection(Vector3.forward).normalized * InteractionRange, Color.yellow);

            ActionUICanvasComponent.HideCanvas(); // ซ่อน ActionUI Canvas
        }
    }
}
