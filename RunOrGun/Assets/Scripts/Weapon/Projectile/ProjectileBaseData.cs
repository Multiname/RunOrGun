using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileBaseData", menuName = "Scriptable Objects/ProjectileBaseData")]
public class ProjectileBaseData : ScriptableObject {
    [field: SerializeField] public float FlightSpeed { get; private set; }
}
