using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] GameManagerData data;

    [SerializeField] Hittable[] players = new Hittable[PlayerIndex.COUNT];

    private void OnEnable() {
        SetSceneReloadingOnPlayerHit();

        #region
        void SetSceneReloadingOnPlayerHit() {
            foreach (var player in players) {
                player.OnHit.AddListener(ReloadBattleScene);
            }
        }
        #endregion
    }

    private void OnDisable() {
        RemoveSceneReloadingFromPlayerHit();

        #region
        void RemoveSceneReloadingFromPlayerHit() {
            foreach (var player in players) {
                player.OnHit.RemoveListener(ReloadBattleScene);
            }
        }
        #endregion
    }

    private async void ReloadBattleScene() {
        await UniTask.WaitForSeconds(data.DelayBeforeNewRound);
        SceneManager.LoadScene("BattleScene");
    }
}
