using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAnimationData", menuName = "Scriptable Objects/PlayerAnimationData")]
public class PlayerAnimationData : ScriptableObject {
    [field: SerializeField] public float DeathAnimationStartHeight { get; private set; }
    [field: SerializeField] public float DeathAnimationStartSpeed { get; private set; }
    [field: SerializeField] public float DeathAnimationAcceleration { get; private set; }
}
