using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float startOffset = 0;
    [SerializeField] private GameObject _a;
    [SerializeField] private GameObject _b;

    private Rigidbody2D _rigidbody2D;
    private float _timer;

    public List<GameObject> ObjectsOnList { get; set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = 0;

        ObjectsOnList = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        Vector2 newPosition = Vector2.Lerp(_a.transform.position, _b.transform.position, Mathf.Sin(_timer + startOffset) * 0.5f + 0.5f);
        Vector2 movement = (newPosition - _rigidbody2D.position);
        foreach (GameObject obj in ObjectsOnList)
        {
            obj.SendMessage("AddMovement", movement);
        }
        _rigidbody2D.MovePosition(newPosition);
        _timer += Time.fixedDeltaTime;
    }
}
