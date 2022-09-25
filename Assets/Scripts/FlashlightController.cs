using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [Header("Scene References")]
    public GameObject FlashlightGO;

    [Header("Parameters")]
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
