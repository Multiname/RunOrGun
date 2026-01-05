using UnityEngine;

public class PointWeaponAtEnemy : MonoBehaviour {
    [SerializeField] Transform enemyTransform;

    private void Update() {
        RotateWeapon();
    }

    private void RotateWeapon() {
        var vectorToEnemy = GetVectorToEnemy();
        var angleOfVector = GetAngleOfVector();
        ApplyAngle();

        #region
        Vector3 GetVectorToEnemy() => enemyTransform.position - transform.position;
        float GetAngleOfVector() => Mathf.Atan2(vectorToEnemy.y, vectorToEnemy.x) * Mathf.Rad2Deg;
        void ApplyAngle() => transform.rotation = Quaternion.Euler(0, 0, angleOfVector);
        #endregion
    }
}