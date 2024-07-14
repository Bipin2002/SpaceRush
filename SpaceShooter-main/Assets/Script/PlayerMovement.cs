using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 100f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] float upthrust = 30f;

    Transform myT;

    void Awake()
    {
        myT = transform;
    }

    void Update()
    {
       
        Thrust();
        Turn();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        myT.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        myT.position += myT.up * upthrust * Time.deltaTime * Input.GetAxis("Upthrust");

    }
}
