using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectCollectable : MonoBehaviour
{
    CollectablesHandler scriptCH;

    private void Awake()
    {
        scriptCH = GameObject.Find("Player").GetComponent<CollectablesHandler>();
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))

        {
            DestroyGameObject();
            scriptCH.scoreAllowed = true;
            Debug.Log("Collectable Destroyed");
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
