using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Initialize(Vector3 direction)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _speed;
        }
    }
}
