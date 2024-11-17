using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    [SerializeField] private Image lifeBarImage;

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    public int Life { get; set; }
    public int GearCount { get; set; }
    public int AttackPower { get; set; }

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
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        Life = PlayerData.MaxLife;
        AttackPower = PlayerData.BaseAttackPower;
        GearCount = 0;
        _isGod = false;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();    
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
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(duration);
        _spriteRenderer.color = Color.white;
        AttackPower = PlayerData.BaseAttackPower;
    }

    public void GodMode(float duration)
    {
        StartCoroutine(GodModeCorutine(duration));
    }

    private IEnumerator GodModeCorutine(float duration)
    {
        _isGod = true;
        _spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(duration);
        _spriteRenderer.color = Color.white;
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
}
