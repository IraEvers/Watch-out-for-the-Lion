using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    PlayerScript scriptPC;
    Animator anim;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) && scriptPC.allowedTojump) || (Input.GetKey(KeyCode.UpArrow) && scriptPC.allowedTojump) || (Input.GetKey(KeyCode.Space) && scriptPC.allowedTojump))
        {
            anim.SetTrigger("jump");
        }
        else{
            anim.SetInteger("Walk", 1);

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0.3f, transform.rotation.z, transform.rotation.w);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = new Quaternion(transform.rotation.x, -0.3f, transform.rotation.z, transform.rotation.w);
        }
        

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0.0f, transform.rotation.z, transform.rotation.w);
        }

    }
}
