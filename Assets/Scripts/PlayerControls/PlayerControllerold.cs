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
        private bool _hasMoved = false;

        //Player's Rigidbody
        private Rigidbody _rb;
        
        public float currentSpeed;

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            currentSpeed = _rb.velocity.magnitude * 3.6f; // m/s'yi km/s'ye çevirir
            SideMovement();
        }

        private void FixedUpdate()
        {
            ConstMovement();
        }

        private void ConstMovement()
        {
            //_rb.transform.Translate(0,0,ınputZ*movementSpeed*Time.fixedDeltaTime);
            _rb.AddForce(Vector3.forward * (movementSpeed * Time.fixedDeltaTime));
        }
        private void SideMovement()
        {
            //hareket etti true ve tuşa bastıysa sola gitti-hareket etti -false oldu eğer
            if (!_hasMoved)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(-2, 0, 0);
                    _hasMoved = true;
                }
                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(2, 0, 0);
                    _hasMoved = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(-2, 0, 0);
                    _hasMoved = false;
                }

                else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(2, 0, 0);
                    _hasMoved = false;
                }
            }
        }

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
       
    }
}