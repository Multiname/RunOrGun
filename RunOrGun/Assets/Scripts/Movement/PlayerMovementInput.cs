using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementInput : IMovementInput {
    public enum PlayerOrder {
        FIRST_PLAYER,
        SECOND_PLAYER
    }

    private GameInput gameInput;
    private InputAction playerInputAction;

    public PlayerMovementInput(PlayerOrder playerOrder) {
        InitGameInput();
        InitPlayerInputAction();

        #region 
        void InitGameInput() {
            gameInput = new GameInput();
            gameInput.Enable();
        }

        void InitPlayerInputAction() {
            if (playerOrder == PlayerOrder.FIRST_PLAYER) {
                playerInputAction = gameInput.Game.FirstPlayerMovement;
            } else {
                playerInputAction = gameInput.Game.SecondPlayerMovement;
            }
        }
        #endregion
    }

    public Vector2 GetMovementDirection() {
        return playerInputAction.ReadValue<Vector2>();
    }

    public void Dispose() {
        gameInput.Disable();
    }
}
