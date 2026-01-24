using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBaseSharedData", menuName = "Scriptable Objects/WeaponBaseSharedData")]
public class WeaponBaseSharedData : ScriptableObject {
    [field: SerializeField] public float FiringInterval { get; private set; }
    [field: SerializeField] public float FiringStartDelay { get; private set; }
    [field: SerializeField] public AimBase Aim { get; private set; }
}
