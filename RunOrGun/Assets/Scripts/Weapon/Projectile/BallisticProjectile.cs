using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallisticProjectile : ProjectileBase {
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        SetVelocity(GetDirection());

        #region
        void SetVelocity(Vector2 flightDirection) => rb.linearVelocity = data.FlightSpeed * flightDirection;
        Vector2 GetDirection() => Vector2.Normalize(TargetCoordinates - (Vector2)transform.position);
        #endregion
    }
}
