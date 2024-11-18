using UnityEngine;

public class TripleJumpPoweUpOnHit : MonoBehaviour
{
    [SerializeField] private SfxClipsData SfxClipsData;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.TripleJump(10.0f);
            AudioManager.Instance.PlayClip(SfxClipsData.GrabClip, AudioSourceType.SFX);
            Destroy(parent);
        }
    }
}
