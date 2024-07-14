using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minSize = .8f;
    [SerializeField] float maxSize = 1.2f;

    Transform myT;
/*    Vector3 randomRotation;*/

     void Awake()
    {
        myT = transform;
    }

    void Start()
    {
        // random size;
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minSize, maxSize);
        scale.y = Random.Range(minSize, maxSize);
        scale.z = Random.Range(minSize, maxSize);

        myT.localScale = scale;

      
    }
/*    void Update()
    {
        
    }*/
}
