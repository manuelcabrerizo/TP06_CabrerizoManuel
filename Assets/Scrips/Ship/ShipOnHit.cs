using UnityEngine;

public class ShipOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ShowEButton();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.HideEButton();
        }
    }
}
