using System.Collections;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _shootTarget;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (enabled)
        {
            Shoot();
            yield return delay;
        }
    }

    private void Shoot()
    {
        Vector3 direction = (_shootTarget.position - transform.position).normalized;
        Bullet bullet = Instantiate(_prefab, transform.position, Quaternion.identity);
        bullet.Initialize(direction);
    }
}
