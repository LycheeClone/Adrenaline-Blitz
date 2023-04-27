using System;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerControllerold : MonoBehaviour
    {
        //Oyuncu sabit hızla ileri gidecek-- Movement speed değişkeni + zaman ilerledikçe artan hız(Time.___) + 
        // A-D ve sağ sol ok tuşları karaktere addforce ile sağa veya sola kuvvet ekleyecek -addforce.vector3 right - left
        //Engele çarpınca engel siyah olsun -- GetComponent
        //Engele çarpınca oyun bitsin (tag kontolüyle varsa oyun durdurma kodu yoksa movement speed sıfıra indir ya da iskinematic true yap)
        //Gameplay 1 dakika
        //Setting Default Movement Speed 
        [SerializeField] private float movementSpeed;

        //Value For The Increasing speed Per Second
        [SerializeField] private float speedIncrease;

        //Value For Controlling Side Movements 
        [SerializeField] private float directionForce;

        //Checking The Player's Move Rights 
        //private bool _hasMoved = false;

        //Player's Rigidbody
        private Rigidbody rb;
        private float moveSpeed = 5f;
        private bool canMoveLeft = true;
        private bool canMoveRight = true;
        private float distanceBetween = 2f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            ConstMovement();

            float horizontalInput = Input.GetAxis("Horizontal");
        
            if (canMoveLeft && horizontalInput < 0)
            {
                canMoveLeft = false;
                canMoveRight = true;
                transform.position += new Vector3(-distanceBetween, 0f, 0f);
            }
            else if (canMoveRight && horizontalInput > 0)
            {
                canMoveRight = false;
                canMoveLeft = true;
                transform.position += new Vector3(distanceBetween, 0f, 0f);
            }

            Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
            rb.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
        }

        private void Update()
        {
           // SideMovement();
        }

        private void ConstMovement()
        {
            //_rb.transform.Translate(0,0,ınputZ*movementSpeed*Time.fixedDeltaTime);
            rb.AddForce(Vector3.back * (movementSpeed * Time.fixedDeltaTime));
        }
        
        
        // private bool canMoveLeft = true;
        // private bool canMoveRight = true;
        //
        // private void SideMovement()
        // {
        //     if (canMoveLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        //     {
        //         transform.Translate(-2, 0, 0);
        //         canMoveLeft = false;
        //         canMoveRight = true;
        //     }
        //     else if (canMoveRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        //     {
        //         transform.Translate(2, 0, 0);
        //         canMoveRight = false;
        //         canMoveLeft = true;
        //     }
        // }
        // private void SideMovement()
        // {
        //     //hareket etti true ve tuşa bastıysa sola gitti-hareket etti -false oldu eğer
        //     if (!_hasMoved)
        //     {
        //         if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //         {
        //             transform.Translate(-2, 0, 0);
        //             _hasMoved = true;
        //         }
        //         else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        //         {
        //             transform.Translate(2, 0, 0);
        //             _hasMoved = true;
        //         }
        //     }
        //     else
        //     {
        //         if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        //         {
        //             transform.Translate(-2, 0, 0);
        //             _hasMoved = false;
        //         }
        //
        //         else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        //         {
        //             transform.Translate(2, 0, 0);
        //             _hasMoved = false;
        //         }
        //     }
        // }


        // private void SideMovement()
        // {
        //     if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //     {
        //         transform.Translate(-2, 0, 0);
        //     }
        //
        //     else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //     {
        //         transform.Translate(2, 0, 0);
        //     }
        // }
    }
}