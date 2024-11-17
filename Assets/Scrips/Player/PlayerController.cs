using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData PlayerData;
    [SerializeField] private Image lifeBarImage;

    private Rigidbody2D _rigidbody2D;
    public int Life { get; set; }
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

        Life = PlayerData.MaxLife;
        AttackPower = PlayerData.BaseAttackPower;
        _isGod = false;
    }

    public void IncreaseLife(int increment)
    {
        Life = Math.Min(Life + increment, PlayerData.MaxLife);
    }

    public void IncreaseAttackPower(float duration)
    { 
        // TODO: start a corutine that imcrement the attack power for X seconds
    }

    public void GodMode(float duration)
    {
        // TODO: start a corutine that make the player a god for X seconds
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
