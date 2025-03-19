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

    void FixedUpdate() // Sử dụng FixedUpdate để xử lý vật lý
    {
        float currentYVelocity = rb.velocity.y;

        Vector3 moveDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;

        if (moveDirection.magnitude > 0.1f) // Kiểm tra có di chuyển không
        {
            rb.velocity = new Vector3(moveDirection.x * speed, currentYVelocity, moveDirection.z * speed);

            // Quay mặt từ từ về hướng di chuyển
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);

            animator.SetBool("isWalking", true);
        }
        else
        {
            rb.velocity = new Vector3(0, currentYVelocity, 0); // Dừng di chuyển
            animator.SetBool("isWalking", false);
        }
    }
}
