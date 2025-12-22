using UnityEngine;

public abstract class WeaponBase : MonoBehaviour {
    [SerializeField] protected WeaponBaseData data;
    [SerializeField] Transform enemyTransform;
    
    protected AimBase aim;
    
    public abstract void StartShooting();
    public abstract void StopShooting();

    protected void Awake() {
        SetAim();

        #region 
        void SetAim() {
            var aimType = data.Aim.GetType();
            aim = gameObject.AddComponent(aimType) as AimBase;
            aim.EnemyTransform = enemyTransform;
        }
        #endregion
    }
}
