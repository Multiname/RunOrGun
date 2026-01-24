using UnityEngine;

[CreateAssetMenu(fileName = "AssaultRifleFireViewData", menuName = "Scriptable Objects/AssaultRifleFireViewData")]
public class AssaultRifleFireViewData : ScriptableObject {
    [field: SerializeField] public float VisibilityDuration { get; private set; }
}
