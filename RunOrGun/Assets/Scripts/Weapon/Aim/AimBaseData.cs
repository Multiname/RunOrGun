using UnityEngine;

[CreateAssetMenu(fileName = "AimBaseData", menuName = "Scriptable Objects/AimBaseData")]
public class AimBaseData : ScriptableObject {
    [field: SerializeField] public float MaxSpreadScale { get; private set; }
}
