using UnityEngine;

public class BulletOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private SfxClipsData SfxClipsData;

    private Rigidbody2D _rigibody2D;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _circleCollider2D;
    private ParticleSystem _particleSys;

    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _circleCollider2D = GetComponentInChildren<CircleCollider2D>();
        _particleSys = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            _particleSys.Play();
            _spriteRenderer.enabled = false;
            _circleCollider2D.enabled = false;
            _rigibody2D.velocity = new Vector2();
            AudioManager.Instance.PlayClip(SfxClipsData.ShootHitClip, AudioSourceType.SFX);
        }
    }
}
