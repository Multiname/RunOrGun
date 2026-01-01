using UnityEngine;

public class AssaultRifleAim : AimBase {
    [SerializeField] MovementBaseData playerMovementBaseData;
    [SerializeField] ProjectileBaseData projectileBaseData;

    public override Vector2 GetFireTargetCoordinates() {
        var spreadScale = Random.Range(-data.MaxSpreadScale, data.MaxSpreadScale);

        var vectorToEnemy = EnemyTransform.position - transform.position;
        var perpendicularVector = new Vector2(-vectorToEnemy.y, vectorToEnemy.x);
        var normalizedVector = Vector2.Normalize(perpendicularVector);
        var scaledVector = normalizedVector * spreadScale;

        var distanceBetweenEnemies = vectorToEnemy.magnitude;
        var playerSpeed = playerMovementBaseData.Speed;
        var projectileSpeed = projectileBaseData.FlightSpeed;
        var maxEnemyEvadeDistance = distanceBetweenEnemies * playerSpeed / Root(SqrPow(projectileSpeed) - SqrPow(playerSpeed));

        var assumedEnemyPosition = (Vector2)EnemyTransform.position + maxEnemyEvadeDistance * scaledVector;
        return assumedEnemyPosition;

        #region
        float Root(float x) => Mathf.Sqrt(x);
        float SqrPow(float x) => Mathf.Pow(x, 2);
        #endregion
    }
}
