using System;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f;
        public float forwardSpeed = 2f;

        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput * speed, 0f, forwardSpeed);
            rb.AddRelativeForce(movement, ForceMode.Force);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= Vector3.right * 2;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * 2;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Vector3 normal = collision.contacts[0].normal;
                rb.velocity = Vector3.Reflect(rb.velocity, normal);
            }
        }
    }
}