using UnityEngine;

[CreateAssetMenu(fileName = "HittableData", menuName = "Scriptable Objects/HittableData")]
public class HittableData : ScriptableObject {
    [field: SerializeField] public Tagged.Tags ProjectileTag { get; private set; }
}
