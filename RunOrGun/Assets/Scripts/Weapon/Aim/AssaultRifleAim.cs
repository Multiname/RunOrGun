using UnityEngine;

public class AssaultRifleAim : AimBase {
    public override Vector2 GetFireTargetCoordinates() {
        return EnemyTransform.position;
    }
}
