using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _spriteTransform;
    private PlayerMovement _playerMovement;
    private BoxCollider2D _boxCollider2D;

    private bool _lastAttack;
    private bool _lastAttackDown;

    public bool Attack { get; set; }
    public bool AttackDown { get; set; }

    private float _attackDirection;
    private float _attackTime;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteTransform = _spriteRenderer.GetComponent<Transform>();
        _playerMovement = GetComponent<PlayerMovement>();
        _boxCollider2D = GetComponentInChildren<BoxCollider2D>();

        Attack = false;
        _lastAttack = false;
        AttackDown = false;
        _lastAttackDown = false;

        _attackDirection = 0.0f;
        _attackTime = 0;
    }

    void Update()
    {
        Vector2 spritePosition = transform.position;

        if (!Attack && !AttackDown && Input.GetKeyDown(PlayerData.AttackLeftKey)) 
        {
            _attackDirection = -1.0f;
            _attackTime = PlayerData.AttackDuration;
            Attack = true;            
        }
        if (!Attack && !AttackDown && Input.GetKeyDown(PlayerData.AttackRightKey))
        {
            _attackDirection = 1.0f;
            _attackTime = PlayerData.AttackDuration;
            Attack = true;
        }

        if (!Attack && !AttackDown && !_playerMovement.Grounded && Input.GetKeyDown(PlayerData.AttackDownKey))
        {
            _attackTime = PlayerData.AttackDuration;
            AttackDown = true;   
        }

        if (_attackTime > 0.0f)
        {
            _boxCollider2D.enabled = true;

            if (Attack)
            {
                _boxCollider2D.offset = new Vector2(0.5f * _attackDirection, -0.19f);
                _boxCollider2D.size = new Vector2(0.6875f, 0.375f);
                spritePosition += Vector2.right * (_attackDirection * _spriteTransform.localScale.x * 0.5f);
                _spriteRenderer.flipX = _attackDirection < 0.0f;
            }
            if (AttackDown)
            {
                _boxCollider2D.offset = new Vector2(0, -0.5f);
                _boxCollider2D.size = new Vector2(0.375f, 0.6875f);
                spritePosition += Vector2.down * (_spriteTransform.localScale.y * 0.5f);
            }            
            _attackTime -= Time.deltaTime;
        }
        else 
        {
            Attack = false;
            AttackDown = false;
            _boxCollider2D.enabled = false;
        }

        if (_playerMovement.Grounded && AttackDown)
        {
            AttackDown = false;
            _boxCollider2D.enabled = false;
            _attackTime = 0.0f;
        }

        _spriteTransform.position = spritePosition;

        UpdateAnimator();

        _lastAttack = Attack;
        _lastAttackDown = AttackDown;
    }

    private void UpdateAnimator()
    {
        if (Attack != _lastAttack)
        {
            _animator.SetBool("Attack", Attack);
        }
        if (AttackDown != _lastAttackDown)
        {
            _animator.SetBool("AttackDown", AttackDown);
        }
    }
}
