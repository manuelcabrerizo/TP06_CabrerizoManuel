using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image lifeBarImage;

    private Rigidbody2D _rigidbody2D;

    public int Life { get; set; }
    public int MaxLife { get; set; }

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

        MaxLife = 10;
        Life = MaxLife;
    }

    public void ApplyDamage(int damage, Vector2 origin)
    {
        Life = Math.Max(Life - damage, 0);
        lifeBarImage.fillAmount = (float)Life / (float)MaxLife;

        Vector2 impulse = (_rigidbody2D.position - origin).normalized * 10.0f;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);
    }

    public void ApplyImpulse(Vector2 origin)
    {
        Vector2 impulse = (_rigidbody2D.position - origin).normalized * 20.0f;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);
    }
}
