using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBaseData", menuName = "Scriptable Objects/WeaponBaseData")]
public class WeaponBaseData : ScriptableObject {
    [field: SerializeField] public float FiringInterval { get; private set; }
    [field: SerializeField] public ProjectileBase Projectile { get; private set; }
    [field: SerializeField] public AimBase Aim { get; private set; }
}
