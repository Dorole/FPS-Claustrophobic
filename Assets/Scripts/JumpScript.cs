using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    Rigidbody player;
    public float speed = 10.0f;
    bool jumping;
    bool isGrounded;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumping = true;
    }

    private void FixedUpdate()
    {
        if(jumping)
        {
            player.AddForce(transform.up * speed, ForceMode.VelocityChange);
            isGrounded = false;
            jumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
     
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }


}
