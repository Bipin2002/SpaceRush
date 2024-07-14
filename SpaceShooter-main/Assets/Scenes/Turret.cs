using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private float bulletSpeed;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var bullet = Instantiate(bulletObject, spawnPoint);
            bullet.transform.localPosition = Vector3.zero;
            bullet.transform.localRotation = Quaternion.Euler(Vector3.zero);
            bullet.transform.SetParent(null);
            bullet.transform.gameObject.SetActive(true);
            bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * bulletSpeed,ForceMode.Impulse);
        }
       
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * 10f * Time.fixedDeltaTime);
    }
}
