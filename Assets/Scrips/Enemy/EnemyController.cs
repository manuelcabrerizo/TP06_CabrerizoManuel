using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData EnemyData;
    [SerializeField] private Image lifeBarImage;
    [SerializeField] private Image backLifeImage;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private ParticleSystem _particleSys;

    public int Life { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _particleSys = GetComponentInChildren<ParticleSystem>();
        _collider = GetComponentInChildren<CircleCollider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Life = EnemyData.MaxLife;
    }

    private void Update()
    {
        if (Life == 0 && _particleSys.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(int damage, Vector2 origin)
    {
        Life = Math.Max(Life - damage, 0);
        lifeBarImage.fillAmount = (float)Life / (float)EnemyData.MaxLife;

        if (Life == 0)
        {
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            _rigidbody2D.gravityScale = 0.0f;
            lifeBarImage.enabled = false;
            backLifeImage.enabled = false;
        }
        else
        {
            Vector2 impulse = (_rigidbody2D.position - origin).normalized * 20.0f;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);
        }
    }
}
