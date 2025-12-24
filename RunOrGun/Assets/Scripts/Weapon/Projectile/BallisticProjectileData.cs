using UnityEngine;

[CreateAssetMenu(fileName = "BallisticProjectileData", menuName = "Scriptable Objects/BallisticProjectileData")]
public class BallisticProjectileData : ScriptableObject {
    [field: SerializeField] public Tagged.Tags HittableTags { get; private set; }
    [field: SerializeField] public float Lifespan { get; private set; }
}
