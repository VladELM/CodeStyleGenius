using System.Collections;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootTarget;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            SetVelocity();
            yield return delay;
        }
    }

    private void SetVelocity()
    {
        Vector3 direction = (_shootTarget.position - transform.position).normalized;
        Bullet bullet = Instantiate(_prefab, transform.position, Quaternion.identity);

        if (bullet.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _speed;
        }
    }
}
