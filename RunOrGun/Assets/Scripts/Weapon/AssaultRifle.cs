using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AssaultRifle : WeaponBase {
    private CancellationTokenSource shootingCts = null;

    private void Start() {
        StartShooting();
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
        while (!ShootingIsCancelled()) {
            SpawnProjectile();
            await WaitForFiringInterval();
        }

        #region 
        bool ShootingIsCancelled() => shootingCts?.Token.IsCancellationRequested ?? true;

        void SpawnProjectile() {
             var projectile = Instantiate(data.Projectile, transform.position, Quaternion.identity);
            projectile.TargetCoordinates = aim.GetFireTargetCoordinates();
            projectile.FireInitiator = gameObject;
        }
        
        async UniTask WaitForFiringInterval() => await UniTask.WaitForSeconds(data.FiringInterval, cancellationToken: shootingCts.Token).SuppressCancellationThrow();
        #endregion
    }

    public override void StopShooting() {
        if (shootingCts != null) {
            shootingCts?.Cancel();
            shootingCts?.Dispose();
            shootingCts = null;
        }
    }
}
