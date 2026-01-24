using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponBase : MonoBehaviour {
    [SerializeField] protected WeaponBaseSharedData sharedData;
    [SerializeField] protected WeaponBaseSingleData singleData;

    [field: SerializeField] protected Transform FirePoint { get; private set; }

    [SerializeField] Transform enemyTransform;

    protected AimBase aim;

    public UnityEvent OnFire;

    public abstract void StartShooting();
    public abstract void StopShooting();

    protected void Awake() {
        SetAim();

        #region 
        void SetAim() {
            aim = Instantiate(sharedData.Aim, transform);
            aim.EnemyTransform = enemyTransform;
        }
        #endregion
    }
}
