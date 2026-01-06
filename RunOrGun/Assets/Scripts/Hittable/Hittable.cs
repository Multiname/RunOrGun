using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour {
    [SerializeField] HittableData data;

    public UnityEvent OnHit;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (HitTagged(out Tagged taggedCollision) && HitProjectile(taggedCollision)) {
            OnHit?.Invoke();
        }

        #region
        bool HitTagged(out Tagged taggedCollision) => collision.TryGetComponent(out taggedCollision);
        bool HitProjectile(Tagged taggedCollision) => taggedCollision.CheckIntersection(data.ProjectileTag);
        #endregion
    }
}