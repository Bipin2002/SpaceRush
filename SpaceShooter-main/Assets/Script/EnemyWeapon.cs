using System.Collections;
using UnityEngine;

public class EnemyFiring : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; 
    [SerializeField] private Transform firePoint; 
    [SerializeField] private float fireRate = 0.5f; 
    [SerializeField] private float bulletSpeed = 1000f; 

    private void Start()
    {
        StartCoroutine(FireBullets());
    }

    private IEnumerator FireBullets()
    {
        while (true)
        {
            FireBullet();
            yield return new WaitForSeconds(1f / fireRate);
        }
    }

    private void FireBullet()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            if (bullet.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
            }
        }
    }
}
