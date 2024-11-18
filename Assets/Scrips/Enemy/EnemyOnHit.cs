using UnityEngine;

public class EnemyOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private ParticleSystem particleSys;

    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            _enemyController.ApplyDamage(PlayerController.Instance.AttackPower, collision.gameObject.transform.position);
            particleSys.Play();
        }
    }
}
