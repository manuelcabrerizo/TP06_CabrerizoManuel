using UnityEngine;

public class EnemyOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            _enemyController.ApplyDamage(1, collision.gameObject.transform.position);
        }
    }
}
