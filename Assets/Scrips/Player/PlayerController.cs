using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    [SerializeField] private Image lifeBarImage;
    [SerializeField] private Image damagePowerUpImage;
    [SerializeField] private Image godPowerUpImage;
    [SerializeField] private Image dobleJumpPowerUpImage;
    [SerializeField] private Image eButtonImage;

    private Rigidbody2D _rigidbody2D;
    public int Life { get; set; }
    public int GearCount { get; set; }
    public int AttackPower { get; set; }
    public bool IsInShop { get; set; }
    public int ShipPartsBuyed { get; set; }

    private bool _hasTripleJump;
    public bool HasTripleJump => _hasTripleJump;

    bool _isGod;

    static public PlayerController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _rigidbody2D = GetComponent<Rigidbody2D>();

        Life = PlayerData.MaxLife;
        AttackPower = PlayerData.BaseAttackPower;
        GearCount = 0;
        IsInShop = false;
        ShipPartsBuyed = 0;

        _isGod = false;
        _hasTripleJump = false;
        damagePowerUpImage.enabled = false;
        godPowerUpImage.enabled = false;
        dobleJumpPowerUpImage.enabled = false;

    }

    private void OnDestroy()
    {
        StopAllCoroutines();    
    }

    private void Update()
    {
        if (!IsInShop && eButtonImage.enabled && Input.GetKeyDown(KeyCode.E))
        {
            UIManager.Instance.SetShopPanelActive(true);
            IsInShop = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            if (IsInShop && Input.GetKeyDown(KeyCode.E))
            {
                IsInShop = false;
                Time.timeScale = 1.0f;
                UIManager.Instance.SetShopPanelActive(false);
            }  
        }
    }

    public bool CanTakeOff()
    {
        return ShipPartsBuyed == 4;
    }

    public bool Lose()
    {
        return Life <= 0;
    }

    public void TripleJump(float duration)
    {
        StartCoroutine(TripleJumpCorutine(duration));
    }

    private IEnumerator TripleJumpCorutine(float duration)
    {
        _hasTripleJump = true;
        dobleJumpPowerUpImage.enabled = true;
        yield return new WaitForSeconds(duration);
        dobleJumpPowerUpImage.enabled = false;
        _hasTripleJump = false;
    }

    public void IncreaseLife(int increment)
    {
        Life = Math.Min(Life + increment, PlayerData.MaxLife);
        lifeBarImage.fillAmount = (float)Life / (float)PlayerData.MaxLife;
    }

    public void IncreaseAttackPower(float duration)
    {
        StartCoroutine(IncreaseAttackPowerCorutine(duration));
    }

    private IEnumerator IncreaseAttackPowerCorutine(float duration)
    {
        AttackPower = PlayerData.IncreaseAttackPower;
        damagePowerUpImage.enabled = true;
        yield return new WaitForSeconds(duration);
        damagePowerUpImage.enabled = false;
        AttackPower = PlayerData.BaseAttackPower;
    }

    public void GodMode(float duration)
    {
        StartCoroutine(GodModeCorutine(duration));
    }

    private IEnumerator GodModeCorutine(float duration)
    {
        _isGod = true;
        godPowerUpImage.enabled = true;
        yield return new WaitForSeconds(duration);
        godPowerUpImage.enabled = false;
        _isGod = false;
    }

    public void ApplyDamage(int damage, Vector2 origin)
    {
        Vector2 impulse = (_rigidbody2D.position - origin).normalized * 10.0f;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);

        if (_isGod)
        {
            return;
        }

        Life = Math.Max(Life - damage, 0);
        lifeBarImage.fillAmount = (float)Life / (float)PlayerData.MaxLife;
    }

    public void ApplyImpulse(Vector2 origin)
    {
        Vector2 impulse = (_rigidbody2D.position - origin).normalized * 20.0f;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);
    }

    public void ShowEButton()
    {
        eButtonImage.enabled = true;
    }

    public void HideEButton()
    {
        eButtonImage.enabled = false;
    }
}
