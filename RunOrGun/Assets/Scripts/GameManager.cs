using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] Hittable[] players = new Hittable[2];

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

    private void ReloadBattleScene() {
        //SceneManager.LoadScene("BattleScene");
    }
}
