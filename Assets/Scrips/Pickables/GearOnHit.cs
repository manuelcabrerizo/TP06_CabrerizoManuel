using UnityEngine;

public class GearOnHit : MonoBehaviour
{
    [SerializeField] private SfxClipsData SfxClipsData;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.GearCount++;
            AudioManager.Instance.PlayClip(SfxClipsData.GrabClip, AudioSourceType.SFX);
            Destroy(parent);
        }
    }
}
