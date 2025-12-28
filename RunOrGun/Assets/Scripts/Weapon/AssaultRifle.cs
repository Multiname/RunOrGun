using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AssaultRifle : WeaponBase {
    private CancellationTokenSource shootingCts = null;
    private UniTaskCompletionSource shotPreparationTcs = new();

    private new void Awake() {
        base.Awake();
        SetShotPrepared();
    }

    private void OnDestroy() {
        StopShooting();
    }

    public override void StartShooting() {
        if (shootingCts == null) {
            shootingCts = new CancellationTokenSource();
            ShootAsync();
        }
    }

    private async void ShootAsync() {
        await WaitForFiringStartDelay();
        while (!ShootingIsStopped()) {
            await WaitForPreparedShot();
            if (ShootingIsStopped()) return;

            SpawnProjectile();
            PrepareToShoot();
        }

        #region
        async UniTask WaitForFiringStartDelay() => await UniTask.WaitForSeconds(data.FiringStartDelay, cancellationToken: shootingCts.Token).SuppressCancellationThrow();
        async UniTask WaitForPreparedShot() => await shotPreparationTcs.Task.AttachExternalCancellation(shootingCts.Token).SuppressCancellationThrow();
        bool ShootingIsStopped() => shootingCts?.Token.IsCancellationRequested ?? true;

        void SpawnProjectile() {
             var projectile = Instantiate(data.Projectile, transform.position, Quaternion.identity);
            projectile.TargetCoordinates = aim.GetFireTargetCoordinates();
            projectile.FireInitiator = gameObject;
        }

        async void PrepareToShoot() {
            shotPreparationTcs = new();
            await UniTask.WaitForSeconds(data.FiringInterval);
            SetShotPrepared();
        }
        #endregion
    }

    private void SetShotPrepared() => shotPreparationTcs.TrySetResult();

    public override void StopShooting() {
        if (shootingCts != null) {
            var oldCts = shootingCts;
            shootingCts = null;
            oldCts.Cancel();
            oldCts.Dispose();
        }
    }
}
