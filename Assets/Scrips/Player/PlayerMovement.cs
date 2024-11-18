using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    [SerializeField] private SfxClipsData SfxClipsData;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private PlayerAttack _playerAttack;

    private LayerMask _tilemapSolidLayer;

    public bool Grounded { get; set; }
    private bool _lastGrounded;
    
    public bool Moving { get; set; }
    private bool _lastMoving;

    private int _jumpCount;

    

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _playerAttack = GetComponent<PlayerAttack>();

        _tilemapSolidLayer = LayerMask.GetMask("Tilemap_Solid");

        Grounded = false;
        _lastGrounded = false;

        Moving = false;
        _lastMoving = false;

        _jumpCount = 0;
    }


    void Update()
    {
        Moving = false;
        if (Input.GetKey(PlayerData.MoveRightKey))
        {
            _rigidbody2D.AddForce(Vector2.right * (PlayerData.Speed * Time.deltaTime), ForceMode2D.Impulse);
            if (!_playerAttack.Attack)
            {
                _spriteRenderer.flipX = false;
            }
            Moving = true;

        }
        if (Input.GetKey(PlayerData.MoveLeftKey))
        {
            _rigidbody2D.AddForce(Vector2.left * (PlayerData.Speed * Time.deltaTime), ForceMode2D.Impulse);
            if (!_playerAttack.Attack)
            {
                _spriteRenderer.flipX = true;
            }
            Moving = true;
        }

        if (Input.GetKeyDown(PlayerData.JumpKey))
        {
            bool hasOtherJump = PlayerController.Instance.HasTripleJump ? _jumpCount < 2 : _jumpCount < 1;
            if (Grounded || hasOtherJump)
            {
                AudioManager.Instance.PlayClip(SfxClipsData.JumpClip, AudioSourceType.SFX);
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0.0f);
                _rigidbody2D.AddForce(Vector2.up * PlayerData.JumpImpulse, ForceMode2D.Impulse);
                _jumpCount++;
            }
        }
        

        ProcessGrounded();
        UpdateAnimator();

        _lastGrounded = Grounded;
        _lastMoving = Moving;
    }


    private void ProcessGrounded()
    {
        float scaleX = transform.localScale.x;
        float scaleY = transform.localScale.y;
        Vector2 origin0 = _rigidbody2D.position + Vector2.left * (scaleX * 0.25f);
        Vector2 origin1 = _rigidbody2D.position + Vector2.right * (scaleX * 0.25f);
        Debug.DrawRay(origin0, Vector2.down * (scaleY * 0.55f), Color.red);
        Debug.DrawRay(origin1, Vector2.down * (scaleY * 0.55f), Color.red);
        RaycastHit2D hitGround0 = Physics2D.Raycast(origin0, Vector2.down, (scaleY * 0.55f), _tilemapSolidLayer);
        RaycastHit2D hitGround1 = Physics2D.Raycast(origin1, Vector2.down, (scaleY * 0.55f), _tilemapSolidLayer);
        Grounded = (hitGround0.collider != null || hitGround1.collider != null);
        if (Grounded)
        {
            _jumpCount = 0;
        }
    }

    private void UpdateAnimator()
    {
        if (Grounded != _lastGrounded)
        {
            _animator.SetBool("Grounded", Grounded);
        }

        if (Moving != _lastMoving)
        {
            _animator.SetBool("Moving", Moving);
        }
    }

    private void AddMovement(Vector2 movement)
    {
        _rigidbody2D.position += movement;
    }
}
