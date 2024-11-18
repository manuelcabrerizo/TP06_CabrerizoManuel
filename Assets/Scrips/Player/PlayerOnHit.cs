using UnityEngine;

public class PlayerOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    [SerializeField] private ParticleSystem particleSys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
            particleSys.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
            particleSys.Play();
        }
    }
}
