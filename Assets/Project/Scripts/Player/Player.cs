using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 3f;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float currentYVelocity = rb.velocity.y;

        Vector3 moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;

        rb.velocity = new Vector3(moveDirection.x * speed, currentYVelocity, moveDirection.z * speed);

        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));
            
            animator.SetBool("isWalking", true); 
        }
        else
        {
            animator.SetBool("isWalking", false); 
        }
    }

}
