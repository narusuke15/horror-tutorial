using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject FlashlightGO;

    public bool IsOn = true;

    void Start()
    {
        FlashlightGO.SetActive(IsOn);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsOn = !IsOn;
            FlashlightGO.SetActive(IsOn);
        }
    }
}
