using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallisticProjectile : ProjectileBase {
    [SerializeField] BallisticProjectileData ballisticProjectileData;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        var direction = GetDirection();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        SetVelocity(GetDirection());
        DestroyAfterLifespan();

        #region
        void SetVelocity(Vector2 flightDirection) => rb.linearVelocity = data.FlightSpeed * flightDirection;
        Vector2 GetDirection() => Vector2.Normalize(TargetCoordinates - (Vector2)transform.position);
        #endregion
    }

    private async void DestroyAfterLifespan() {
        await UniTask.WaitForSeconds(ballisticProjectileData.Lifespan);
        if (this) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (HitTarget()) {
            Destroy(gameObject);
        }

        #region
        bool HitTarget() => !HitFireInitiator() && HitHittable();

        bool HitFireInitiator() => collider.gameObject == FireInitiator;
        bool HitHittable() {
            if (collider.TryGetComponent(out Tagged taggedCollided)) {
                return TaggedIsHittable(taggedCollided);
            }
            return false;
        }
        bool TaggedIsHittable(Tagged tagged) => tagged.CheckIntersection(ballisticProjectileData.HittableTags);
        #endregion
    }
}
