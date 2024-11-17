using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
public class SpawnedBullet
{
    public GameObject Obj;
    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public CircleCollider2D Collider;
    public float timer;
}

public class BullletSpawner : MonoBehaviour
{
    public static BullletSpawner Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private IObjectPool<SpawnedBullet> _bulletPool;

    void Awake()
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

        _bulletPool = new ObjectPool<SpawnedBullet>(
            CreateObject,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public SpawnedBullet SpawnBullet(float lifeTime)
    {
        SpawnedBullet bullet = _bulletPool.Get();
        bullet.timer = lifeTime;
        StartCoroutine(DestroyBulletAfterTimelife(bullet));
        return bullet;
    }

    private IEnumerator DestroyBulletAfterTimelife(SpawnedBullet bullet)
    {
        yield return new WaitForSeconds(bullet.timer);
        _bulletPool.Release(bullet);
    }

    private SpawnedBullet CreateObject()
    {
        GameObject obj = Instantiate(bulletPrefab);
        SpawnedBullet bullet = new SpawnedBullet();

        bullet.Obj = obj;
        bullet.Body = obj.GetComponent<Rigidbody2D>();
        bullet.Sprite = obj.GetComponentInChildren<SpriteRenderer>();
        bullet.Collider = obj.GetComponentInChildren<CircleCollider2D>();

        bullet.Obj.SetActive(false);
        bullet.Sprite.enabled = false;
        bullet.Collider.enabled = false;
        bullet.Body.position = new Vector2();

        return bullet;
    }

    private void OnReleaseToPool(SpawnedBullet pooledObject)
    {
        pooledObject.Obj.SetActive(false);
        pooledObject.Sprite.enabled = false;
        pooledObject.Collider.enabled = false;
        pooledObject.Body.position = new Vector2();
    }

    private void OnGetFromPool(SpawnedBullet pooledObject)
    {
        pooledObject.Obj.SetActive(true);
    }

    private void OnDestroyPooledObject(SpawnedBullet pooledObject)
    {
        Destroy(pooledObject.Obj);
    }
}
