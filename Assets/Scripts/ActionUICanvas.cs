using UnityEngine;
using TMPro; // การจะเรียกใช้ TextMeshPro ต้องประกาศการเรียกใช้ namespace นี้

/// <summary>
/// Scripts ควบคุม Action UI ตอนที่ผู้เล่นสามารถทำอะไรบางอย่างกับ GameObject ได้
/// </summary>
public class ActionUICanvas : MonoBehaviour
{
    [Header("References")]
    public TMP_Text ActionText; // text ที่จะขึ้นเมื่อสามารถทำอะไรกับ GameObject ได้
    Canvas _canvas; // ตัวแปรอ้างอิง Canvas ActionUI

    void Awake()
    {
        _canvas = GetComponent<Canvas>(); // ดึง Canvas ที่อยู่ใน GameObject นี้ (ActionUICanvas)
    }

    // แสดง canvas
    public void ShowCanvas()
    {
        if (!_canvas.enabled)
            _canvas.enabled = true;
    }

    // ซ่อน canvas
    public void HideCanvas()
    {
        if (_canvas.enabled)
            _canvas.enabled = false;
    }

    // แสดง canvas พร้อม action text ที่ต้องการ
    public void ShowInteractionUI(string interactionText)
    {
        ShowCanvas();
        ActionText.text = interactionText; // แสดง ActionText
    }
}
