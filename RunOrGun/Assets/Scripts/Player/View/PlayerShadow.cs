using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerShadow : MonoBehaviour {
    [SerializeField] Sprite bigShadow;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBigShadow() {
        spriteRenderer.sprite = bigShadow;
    }
}
