using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour {
    [SerializeField] PlayerAnimationData data;

    private Animator animator;

    private bool IsRunning {
        set => animator.SetBool("isRunning", value);
    }

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetRunning() => IsRunning = true;
    public void UnsetRunning() => IsRunning = false;
    public void SetDead() {
        animator.SetBool("isDead", true);
        PlayDeathAnimationAsync();
    }

    private async void PlayDeathAnimationAsync() {
        SetStartPosition();
        float speed = GetStartSpeed();

        while (PositionIsAboveZero()) {
            await UniTask.Yield();
            Move(speed);
            Accelerate(ref speed);
        }

        SetZeroPosition();

        #region
        void SetStartPosition() {
            var startPosition = transform.localPosition;
            startPosition.y = data.DeathAnimationStartHeight;
            transform.localPosition = startPosition;
        }

        float GetStartSpeed() => data.DeathAnimationStartSpeed;
        bool PositionIsAboveZero() => transform.localPosition.y > 0;
        void Move(float speed) => transform.localPosition += speed * Time.deltaTime * Vector3.up;
        void Accelerate(ref float speed) => speed += data.DeathAnimationAcceleration * Time.deltaTime;

        void SetZeroPosition() {
            var position = transform.localPosition;
            position.y = 0;
            transform.localPosition = position;
        }
        #endregion
    }
}