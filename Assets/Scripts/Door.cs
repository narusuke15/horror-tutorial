using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public TMP_Text ActionText;
    public GameObject Crosshair;
    Animator _doorAnimator;
    Player _playerComponent;
    bool _isOpen;

    void Start()
    {
        _playerComponent = FindObjectOfType<Player>();
        _doorAnimator = GetComponent<Animator>();
    }

    // function พิเศษ ทำงานเมื่อชี้เมาส์ไปที่วัตถุที่ component นี้เกาะอยู่
    void OnMouseOver()
    {
        if (_playerComponent.DistanceFromTarget < 1.8f)
        {
            ActionText.gameObject.SetActive(true);
            Crosshair.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen;
                _doorAnimator.SetBool("IsOpen", _isOpen);
                StartCoroutine(DisableColliderRoutine(0.5f));
            }

            if (_isOpen)
                ActionText.text = "- Close Door -";
            else
                ActionText.text = "- Open Door -";
        }
        else
        {
            HideActionUI();
        }
    }

    void OnMouseExit()
    {
        HideActionUI();
    }

    void HideActionUI()
    {
        ActionText.gameObject.SetActive(false);
        Crosshair.SetActive(false);
    }

    IEnumerator DisableColliderRoutine(float delaySeconds)
    {
        Collider colliderComponent = GetComponent<Collider>();
        colliderComponent.enabled = false;
        yield return new WaitForSeconds(delaySeconds);
        colliderComponent.enabled = true;
    }
}
