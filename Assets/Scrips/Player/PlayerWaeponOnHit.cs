using UnityEngine;


public class PlayerWaeponOnHit : MonoBehaviour
{
    [SerializeField] private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.CheckCollisionLayer(collision.gameObject, layer))
        {
            PlayerController.Instance.ApplyImpulse(collision.gameObject.transform.position);
        }
    } 
}
