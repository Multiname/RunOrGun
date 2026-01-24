using UnityEngine;

public class FlipPlayer : MonoBehaviour {
    [SerializeField] Transform enemyTransform;

    private void Update() {
        FlipTowardEnemy();
    }

    private void FlipTowardEnemy() {
        var vectorToEnemy = enemyTransform.position - transform.position;
        var scale = transform.localScale;
        scale.x = Mathf.Sign(vectorToEnemy.x);
        transform.localScale = scale;
    }
}
