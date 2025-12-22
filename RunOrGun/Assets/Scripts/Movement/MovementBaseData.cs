using UnityEngine;

[CreateAssetMenu(fileName = "MovementBaseData", menuName = "Scriptable Objects/MovementBaseData")]
public class MovementBaseData : ScriptableObject {
    [field: SerializeField] public float Speed { get; private set; }
}
