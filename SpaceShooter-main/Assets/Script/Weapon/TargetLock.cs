using UnityEngine;

public class TargetLock : MonoBehaviour
{
    public Transform currentTarget;
    public float lockRange = 50f;

    void Update()
    {
        if (Input.GetButtonDown("LockTarget"))
        {
            LockOntoTarget();
        }
    }

    void LockOntoTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && distanceToEnemy <= lockRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            currentTarget = nearestEnemy.transform;
            Debug.Log("Target Locked: " + currentTarget.name);
        }
    }
}
