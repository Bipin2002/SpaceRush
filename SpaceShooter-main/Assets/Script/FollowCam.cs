using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new(0f, 2f, -20f);
    [SerializeField] float distanceDamp = 10f;
    [SerializeField] float rotationDamp = 5f;
    private Transform myT;

    void Awake()
    {
        myT = transform;
    }

    void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
        myT.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationDamp * Time.deltaTime);
        myT.rotation = curRot;

    }
}
