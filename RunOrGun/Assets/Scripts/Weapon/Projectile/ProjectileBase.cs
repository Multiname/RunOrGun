using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour {
    public ProjectileBaseData data;

    public Vector2 TargetCoordinates { protected get; set; }
    public GameObject FireInitiator { protected get; set; }
}
