using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AssaultRifleFireView : MonoBehaviour {
    [SerializeField] AssaultRifleFireViewData data;

    [SerializeField] WeaponBase weapon;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        weapon.OnFire.AddListener(ShowFire);
    }

    private void OnDisable() {
        weapon.OnFire.RemoveListener(ShowFire);
    }

    public async void ShowFire() {
        spriteRenderer.enabled = true;

        await UniTask.WaitForSeconds(data.VisibilityDuration);
        spriteRenderer.enabled = false;
    }
}