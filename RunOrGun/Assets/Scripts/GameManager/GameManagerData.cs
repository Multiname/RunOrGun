using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerData", menuName = "Scriptable Objects/GameManagerData")]
public class GameManagerData : ScriptableObject {
    [field: SerializeField] public float DelayBeforeNewRound { get; private set; }
}
