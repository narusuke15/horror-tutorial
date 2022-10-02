using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Transform PlayerTransform;

    public static GameObject HitRef;
    
    [Header("Debug")]
    public float DistanceFromTarget;
    public string HitName;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(PlayerTransform.position, PlayerTransform.TransformDirection(Vector3.forward), out hit))
        {
            DistanceFromTarget = hit.distance;
            HitName = hit.collider.name;
            HitRef = hit.collider.gameObject;
        }
        else
        {
            DistanceFromTarget = 0;
            HitName = "none";
            HitRef = null;
        }
    }
}
