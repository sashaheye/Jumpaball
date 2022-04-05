using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;


public class Jump : MonoBehaviour
{

    Rigidbody rb;
    public float jumpHeight = 10;
    public bool grounded;
    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0))
        {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jumpsRemaining -= 1;
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

}

