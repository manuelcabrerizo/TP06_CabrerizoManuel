using UnityEngine;

public class PlayerOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
        }
    }
}
