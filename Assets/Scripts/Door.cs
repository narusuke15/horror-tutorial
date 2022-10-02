using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // การจะเรียกใช้ TextMeshPro ต้องประกาศการเรียกใช้ namespace นี้

/// <summary>
/// Scripts ควบคุม interaction และ animation ของประตู
/// </summary>
public class Door : MonoBehaviour
{
    [Header("References")]
    public TMP_Text ActionText; // text ที่จะขึ้นถ้าเราสามารถเปิดปิดประตูได้
    public GameObject Crosshair; // เป้าที่จะขึ้นตอนเปิดปิดประตูได้
    Animator _doorAnimator; // Animator ที่ควบคุม animation การเปิดปิดของประตู
    Player _playerComponent; // ดึงมาเรียกใช้ข้อมูล raycast ของ Player

    bool _isOpen; // เก็บค่าการเปิดปิดของประตูเพื่อเอาไปควบคุม Animator ของประตู

    void Start()
    {
        // ใช้โค้ด referencs component
        // FindObjectOfType<T>() >> ทำการหา component ใน Scene ที่มี type ใน <...>
        // -- เหมาะกับ scene ที่มี component อันนี้อันเดียว
        _playerComponent = FindObjectOfType<Player>();
        // GetComponent<T>() ใช้หา component ที่อยู่ใน GameObject ที่ script นี้ติดอยู่
        // -- เหมาะกับการเรียก component ที่เรารู้ว่ามันอยู่ใน GameObject เดียวกัน
        _doorAnimator = GetComponent<Animator>();
    }

    // function พิเศษ ทำงานตลอดเวลาเมื่อชี้เมาส์ไปที่วัตถุที่ component นี้เกาะอยู่
    void OnMouseOver()
    {
        // ถ้าระยะของผู้เล่นกับวัตถุน้อยกว่า 1.8 เมตร
        if (_playerComponent.DistanceFromTarget < 1.8f)
        {
            // เปิด action UI
            ActionText.gameObject.SetActive(true);
            Crosshair.SetActive(true);

            // แสดง ActionText เปิดปิดประตู
            if (_isOpen)
                ActionText.text = "- Close Door -";
            else
                ActionText.text = "- Open Door -";

            // เปิดปิดประตูเมื่อผู้เล่นกด 'e'
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen; // สลับค่าเปิดปิด
                _doorAnimator.SetBool("IsOpen", _isOpen); // ปรับ parameter 'IsOpen' ใน Animator (เดี๋ยวมันจัดการที่เหลือให้เอง)
                StartCoroutine(DisableColliderRoutine());
            }
        }
        // ซ่อน Action UI ถ้าระยะห่างเกิน 8 เมตร
        else
        {
            HideActionUI();
        }
    }

    // function พิเศษ ทำงานตลอดเวลาเมื่อชี้เมาส์ออกจากวัตถุที่ component นี้เกาะอยู่
    void OnMouseExit()
    {
        HideActionUI(); // ซ่อน Action UI
    }

    // ปิด action UI
    void HideActionUI()
    {
        ActionText.gameObject.SetActive(false);
        Crosshair.SetActive(false);
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
