using UnityEngine;

public abstract class AimBase : MonoBehaviour {
    [SerializeField] protected AimBaseData data;
    
    [HideInInspector] public Transform EnemyTransform { protected get; set; }

    public abstract Vector2 GetFireTargetCoordinates();
}
