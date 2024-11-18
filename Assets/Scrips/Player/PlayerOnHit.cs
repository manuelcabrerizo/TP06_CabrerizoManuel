using UnityEngine;

public class PlayerOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private SfxClipsData SfxClipsData;
    [SerializeField] private ParticleSystem particleSys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            AudioManager.Instance.PlayClip(SfxClipsData.HitClip, AudioSourceType.SFX);
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
            particleSys.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            AudioManager.Instance.PlayClip(SfxClipsData.HitClip, AudioSourceType.SFX);
            PlayerController.Instance.ApplyDamage(1, collision.gameObject.transform.position);
            particleSys.Play();
        }
    }
}
