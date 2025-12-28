using UnityEngine;

[RequireComponent(typeof(MovementBase))]
[RequireComponent(typeof(WeaponBase))]
public class PlayerController : MonoBehaviour {
    private MovementBase movement;
    private WeaponBase weapon;

    private void Awake() {
        movement = GetComponent<MovementBase>();
        weapon = GetComponent<WeaponBase>();
    }

    private void OnEnable() {
        movement.OnStartMoving.AddListener(weapon.StopShooting);
        movement.OnStopMoving.AddListener(weapon.StartShooting);
    }

    private void OnDisable() {
        movement.OnStartMoving.RemoveListener(weapon.StopShooting);
        movement.OnStopMoving.RemoveListener(weapon.StartShooting);
    }
}
