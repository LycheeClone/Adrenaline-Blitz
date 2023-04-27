using System;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float forwardSpeed = 2f;

        void Update()
        {
            
        }

        private void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput * speed, 0f, forwardSpeed *Time.fixedDeltaTime);
            transform.Translate(movement * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= Vector3.right * 2;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * 2;
            }
        }
    }
}