using UnityEngine;

public class MovingPlatformOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;


    private MovingPlatform _movingPlatform;

    private Transform _parentTransform;

    private void Awake()
    {
        _movingPlatform = GetComponentInParent<MovingPlatform>();
        _parentTransform = _movingPlatform.GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            _movingPlatform.ObjectsOnList.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
           _movingPlatform.ObjectsOnList.Remove(collision.gameObject);
        }
    }
}
