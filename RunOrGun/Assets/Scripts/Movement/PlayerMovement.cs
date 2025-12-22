using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MovementBase {
    [SerializeField] PlayerMovementInput.PlayerOrder playerOrder;

    private Rigidbody2D rb;
    private Vector2 currentMovementDirection = Vector2.zero;
    private Vector2 previousMovementDirection = Vector2.zero;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        movementInput = new PlayerMovementInput(playerOrder);
    }

    private void Update() {
        previousMovementDirection = currentMovementDirection;
        currentMovementDirection = ReadMovement();
    }

    private void FixedUpdate() {
        Move();
        CheckMovingEvents();
    }

    private void Move() {
        rb.linearVelocity = data.Speed * currentMovementDirection;
    }

    private void CheckMovingEvents() {
        if (MovementStarted()) {
            OnStartMoving?.Invoke();
        } else if (MovementStopped()) {
            OnStopMoving?.Invoke();
        }

        #region 
        bool MovementStarted() => !IsZero(currentMovementDirection) && IsZero(previousMovementDirection);
        bool MovementStopped() => IsZero(currentMovementDirection) && !IsZero(previousMovementDirection);
        static bool IsZero(Vector2 vector) => vector == Vector2.zero;
        #endregion
    }
}
