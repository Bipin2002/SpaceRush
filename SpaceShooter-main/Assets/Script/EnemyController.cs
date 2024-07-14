using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementspeed = 10f;
    [SerializeField] float roationDamp = .5f;


    void Update()
    {
        Turn();
        Move();
    }

    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, roationDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementspeed * Time.deltaTime;
    }
}