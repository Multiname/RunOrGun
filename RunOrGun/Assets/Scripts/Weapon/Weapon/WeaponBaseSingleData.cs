using UnityEngine;

[CreateAssetMenu(fileName = "WeaponBaseSingleData", menuName = "Scriptable Objects/WeaponBaseSingleData")]
public class WeaponBaseSingleData : ScriptableObject {
    [field: SerializeField] public ProjectileBase Projectile { get; private set; }
}