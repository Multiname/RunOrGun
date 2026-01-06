using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {
    [SerializeField] protected WeaponBaseSharedData sharedData;
    [SerializeField] protected WeaponBaseSingleData singleData;
    [SerializeField] Transform enemyTransform;
    
    protected AimBase aim;
    
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
