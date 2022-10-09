using System.Collections; // ประกาศเพื่อใช้งาน Corountine
using UnityEngine;

/// <summary>
/// Scripts ควบคุม interaction และ animation ของประตู
/// </summary>
public class Door : MonoBehaviour
{
    [Header("References")]
    public Animator DoorAnimator; // Animator ที่ควบคุม animation การเปิดปิดของประตู
    bool _isOpen; // เก็บค่าการเปิดปิดของประตูเพื่อเอาไปควบคุม Animator ของประตู

    // ส่ง interation เปิดปิดประตู ให้กับ scripts ที่เรียกใช้
    public string GetInteractionText()
    {
        // สถานะ interation จะเปลี่ยนตามสถานะประตู
        if (_isOpen)
            return "- [e] Close Door -";
        else
            return "- [e] Open Door -";
    }

    public void Interact()
    {
        _isOpen = !_isOpen; // สลับค่าเปิดปิด
        DoorAnimator.SetBool("IsOpen", _isOpen); // ปรับ parameter 'IsOpen' ใน Animator (เดี๋ยวมันจัดการที่เหลือให้เอง)
        StartCoroutine(DisableColliderRoutine());
    }

    // พยายามแก้บัคโดนประตูดีดตก map ด้วยการปิด collider ชั่วคราว
    IEnumerator DisableColliderRoutine()
    {
        Collider colliderComponent = GetComponent<Collider>();
        colliderComponent.enabled = false;
        yield return new WaitForSeconds(0.5f); // รอ 0.5 วิ (= เวลาตอนประตูเคลื่อนที่)
        colliderComponent.enabled = true;
    }
}
