using UnityEngine;

[RequireComponent(typeof(MovementBase))]
[RequireComponent(typeof(WeaponBase))]
[RequireComponent(typeof(Hittable))]
public class PlayerController : MonoBehaviour {
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] WeaponVisibility weaponVisibility;
    [SerializeField] PlayerShadow playerShadow;
    [SerializeField] FlipPlayer flipPlayer;
    [SerializeField] PlayerController enemyPlayerController;

    [field: SerializeField] public PlayerIndex.Index PlayerIndex { get; private set; }

    private MovementBase movement;
    private WeaponBase weapon;
    private Hittable hittable;

    private void Awake() {
        movement = GetComponent<MovementBase>();
        weapon = GetComponent<WeaponBase>();
        hittable = GetComponent<Hittable>();
    }

    private void OnEnable() {
        movement.OnStartMoving.AddListener(weapon.StopShooting);
        movement.OnStopMoving.AddListener(weapon.StartShooting);

        movement.OnStartMoving.AddListener(playerAnimation.SetRunning);
        movement.OnStopMoving.AddListener(playerAnimation.UnsetRunning);

        movement.OnStartMoving.AddListener(weaponVisibility.HideWeapon);
        movement.OnStopMoving.AddListener(weaponVisibility.ShowWeapon);

        hittable.OnHit.AddListener(HandlePlayerHit);
    }

    private void OnDisable() {
        movement.OnStartMoving.RemoveListener(weapon.StopShooting);
        movement.OnStopMoving.RemoveListener(weapon.StartShooting);

        movement.OnStartMoving.RemoveListener(playerAnimation.SetRunning);
        movement.OnStopMoving.RemoveListener(playerAnimation.UnsetRunning);

        movement.OnStartMoving.RemoveListener(weaponVisibility.HideWeapon);
        movement.OnStopMoving.RemoveListener(weaponVisibility.ShowWeapon);

        hittable.OnHit.RemoveListener(HandlePlayerHit);
    }

    private void HandlePlayerHit() {
        weapon.StopShooting();
        weapon.enabled = false;

        enemyPlayerController.DisableWeapon();
        enemyPlayerController.DisableTakenDamage();

        hittable.OnHit.RemoveListener(HandlePlayerHit);
        hittable.enabled = false;

        movement.enabled = false;
        flipPlayer.enabled = false;

        weaponVisibility.HideWeapon();
        playerShadow.SetBigShadow();
        playerAnimation.SetDead();

        LeftPanel.Instance.IncrementPlayerScore(enemyPlayerController.PlayerIndex);
    }

    public void DisableWeapon() {
        weapon.StopShooting();
        movement.OnStartMoving.RemoveListener(weapon.StopShooting);
        movement.OnStopMoving.RemoveListener(weapon.StartShooting);
        weapon.enabled = false;
    }

    public void DisableTakenDamage() {
        hittable.OnHit.RemoveListener(HandlePlayerHit);
        hittable.enabled = false;
    }
}
