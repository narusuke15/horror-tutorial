using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    public FlashlightController Flashlight;

    public string GetInteractionText()
    {
        return "- [e] take battery -";
    }

    public void Interact()
    {
        Flashlight.AddBattery(1);
        Destroy(transform.parent.gameObject);
    }
}
