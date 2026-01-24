using UnityEngine;

public class PointWeaponAtEnemy : MonoBehaviour {
    [SerializeField] Transform enemyTransform;

    private void Update() {
        RotateWeapon();
    }

    private void RotateWeapon() {
        var vectorToEnemy = GetVectorToEnemy();
        var angleOfVector = GetAngleOfVector();

        if (PlayerIsFlipped()) {
            FlipAngle();
        }
        ApplyAngle();

        #region
        Vector3 GetVectorToEnemy() => enemyTransform.position - transform.position;
        float GetAngleOfVector() => Mathf.Atan2(vectorToEnemy.y, vectorToEnemy.x) * Mathf.Rad2Deg;
        bool PlayerIsFlipped() => transform.lossyScale.x < 0;
        void FlipAngle() => angleOfVector += 180;
        void ApplyAngle() => transform.rotation = Quaternion.Euler(0, 0, angleOfVector);
        #endregion
    }
}