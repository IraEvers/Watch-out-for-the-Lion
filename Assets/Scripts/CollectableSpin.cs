using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpin : MonoBehaviour
{
    private float speed = 20f;
    
    
    void Update ()
    {
        transform.Rotate(transform.rotation.x, speed * Time.deltaTime, transform.rotation.z );
    }
}
