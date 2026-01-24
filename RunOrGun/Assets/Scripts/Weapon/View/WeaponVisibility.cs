using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponVisibility : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ShowWeapon() {
        spriteRenderer.enabled = true;
    }

    public void HideWeapon() {
        spriteRenderer.enabled = false;
    }
}
