using System.Collections;
using UnityEngine;

public class BulletHandlers : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 1000f;
    public int damage;
    public string[] hitTags;
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    [SerializeField] private float maxDistance = 1000f;

    private Vector3 startPosition;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    public void LaunchMissile(Transform point)
    {
        rb.AddForce(point.forward * speed, ForceMode.Impulse);
        StartCoroutine(CheckDistance());
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in hitTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                HealthHandler healthHandler = collision.gameObject.GetComponent<HealthHandler>();
                if (healthHandler != null)
                {
                    healthHandler.TakeDamage(damage);
                }

                TriggerExplosion();
                Destroy(gameObject);
                return;
            }
        }
    }

    private void TriggerExplosion()
    {
        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
        }

        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }

    private IEnumerator CheckDistance()
    {
        while (true)
        {
            float distanceTraveled = Vector3.Distance(startPosition, transform.position);
            if (distanceTraveled > maxDistance)
            {
                Destroy(gameObject);
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
