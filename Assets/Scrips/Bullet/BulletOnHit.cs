using UnityEngine;

public class BulletOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private Rigidbody2D _rigibody2D;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;

    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _circleCollider2D = GetComponentInChildren<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            gameObject.SetActive(false);
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            _rigibody2D.position = new Vector2();
        }
    }
}
