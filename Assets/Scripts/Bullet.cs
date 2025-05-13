using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
            _rigidbody = rigidbody;
    }

    public void Initialize(Vector3 direction)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            _rigidbody.transform.up = direction;
            _rigidbody.velocity = direction * _speed;
        }
    }
}
