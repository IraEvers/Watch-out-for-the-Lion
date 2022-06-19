using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    PlayerScript scriptPC;

    private float posZ;
    private float playerZ;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Start()
    {
        posZ = transform.position.z;
    }

    void Update()
    {
        playerZ = scriptPC.transform.position.z;

        if((posZ + 8) <= playerZ)
        {
            DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
