using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private Rigidbody2D _targetRigidBody2D;

    private float _timeToShoot = 3.0f;
    private float _time = 0;
    private float _shootSpeed = 4.0f;
    private float _shootRadio = 8.0f;

    private void Awake()
    {
        _time = _timeToShoot;
        _targetRigidBody2D = target.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Utils.DrawDebugCircle(transform.position, _shootRadio, 20);
        float distSq = (_targetRigidBody2D.position - (Vector2)transform.position).sqrMagnitude;
        if (distSq < (_shootRadio * _shootRadio))
        {
            _time -= Time.deltaTime;
            if (_time < 0.0)
            {
                SpawnedBullet bullet = BullletSpawner.Instance.SpawnBullet(5.0f);
                bullet.Obj.transform.position = transform.position;
                bullet.Body.position = transform.position;
                bullet.Body.velocity = Vector2.zero;
                Vector2 shootDir = _targetRigidBody2D.position - bullet.Body.position;
                shootDir = Vector2.Dot(Vector2.right, shootDir) * Vector2.right;
                bullet.Body.AddForce(shootDir.normalized * _shootSpeed, ForceMode2D.Impulse);
                bullet.Sprite.enabled = true;
                bullet.Collider.enabled = true;

                _time = _timeToShoot;
            }
        }
    }
}
