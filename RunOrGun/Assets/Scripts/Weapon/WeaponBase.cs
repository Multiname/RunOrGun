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
            aim = Instantiate(data.Aim, transform);
            aim.EnemyTransform = enemyTransform;
        }
        #endregion
    }
}
