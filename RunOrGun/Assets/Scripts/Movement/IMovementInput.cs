using System;
using UnityEngine;

public interface IMovementInput : IDisposable {
    public Vector2 GetMovementDirection();
}
