using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData EnemyData;
    [SerializeField] private Image lifeBarImage;
    private Rigidbody2D _rigidbody2D;

    public int Life { get; set; }

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Life = EnemyData.MaxLife;
    }

    public void ApplyDamage(int damage, Vector2 origin)
    {
        Life = Math.Max(Life - damage, 0);
        lifeBarImage.fillAmount = (float)Life / (float)EnemyData.MaxLife;

        Vector2 impulse = (_rigidbody2D.position - origin).normalized * 20.0f;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(impulse, ForceMode2D.Impulse);

        if (Life == 0)
        {
            Destroy(gameObject);
        }
    }
}
