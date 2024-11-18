using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private EnemyData EnemyData;
    [SerializeField] private GameObject target;
    [SerializeField] private SfxClipsData SfxClipsData;

    private Rigidbody2D _targetRigidBody2D;
    private float _time;

    private void Awake()
    {
        _time = EnemyData.TimeToShoot;
        _targetRigidBody2D = target.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Utils.DrawDebugCircle(transform.position, EnemyData.ShootRadio, 20);
        float distSq = (_targetRigidBody2D.position - (Vector2)transform.position).sqrMagnitude;
        if (distSq < (EnemyData.ShootRadio * EnemyData.ShootRadio))
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
                bullet.Body.AddForce(shootDir.normalized * EnemyData.ShootSpeed, ForceMode2D.Impulse);
                bullet.Sprite.enabled = true;
                bullet.Collider.enabled = true;

                AudioManager.Instance.PlayClip(SfxClipsData.ShootFireClip, AudioSourceType.SFX);

                _time = EnemyData.TimeToShoot;
            }
        }
    }
}
