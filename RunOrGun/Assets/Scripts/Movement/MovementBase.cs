using UnityEngine;
using UnityEngine.Events;

public class MovementBase : MonoBehaviour {
    [SerializeField] protected MovementBaseData data;

    protected IMovementInput movementInput;

    public UnityEvent OnStartMoving;
    public UnityEvent OnStopMoving;

    protected Vector2 ReadMovement() => movementInput.GetMovementDirection();
}