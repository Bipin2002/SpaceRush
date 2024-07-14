using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    private TargetLock targetLock;

    void Start()
    {
        targetLock = GetComponent<TargetLock>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (targetLock.currentTarget != null)
        {
            Vector3 direction = (targetLock.currentTarget.position - firePoint.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = direction * bulletSpeed;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
