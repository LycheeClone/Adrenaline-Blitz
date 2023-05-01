using System;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        public Transform playerTransform;

        //Default Movement Speed
        private float _movementSpeed = 1000;

        //Side Direction Move Controller Variable
        private bool _hasMoved = false;

        //Player's Rigidbody
        private Rigidbody _rb;

        //The variable that holds the right to move Left
        private bool _canMoveLeft = true;

        //the variable that holds the right to move right
        private bool _canMoveRight = true;

        private float hiz = 20f; // Nesnenin başlangıç hızı
        private float hizArtisi = 1f; // Hız artış miktarı
        private float zamanlayici = 0.5f; // Hız artışının zamanlayıcısı
        private float zamanSayaci = 0.0f; // Geçen süreyi tutar

        private void Awake()
        {
            playerTransform = transform;
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }
        void Update() {
            SideMovement();
            zamanSayaci += Time.deltaTime;
            if (zamanSayaci > zamanlayici) {
                hiz += hizArtisi;
                zamanSayaci = 0.0f;
            }
            print(Time.time);
        }

        void FixedUpdate() {
            if (transform.position.z >= 500)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * 70, ForceMode.Acceleration);
            }
            if (transform.position.z >= 640)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, GetComponent<Rigidbody>().velocity.z);
            }
            Vector3 yon = new Vector3(0, 0, 1); // Yön vektörü, nesnenin ilerleme yönüne göre ayarlanacak
            _rb.AddForce(yon.normalized * hiz, ForceMode.Acceleration); // Nesneye hız kazandır

            // Maksimum hızı sınırlandır
            if (_rb.velocity.magnitude > hiz) {
                _rb.velocity = _rb.velocity.normalized * hiz;
            }
        }
    
    //
    // private void FixedUpdate()
    //     {
    //         //ConstMovement();
    //     }
        private void ConstMovement()
        {
            
            //_rb.AddForce(Vector3.forward * (_movementSpeed * Time.fixedDeltaTime));
            
        }

        //Function That Determines the Character's Ability to Move Left and Right
        private void SideMovement()
        {
            if (!_hasMoved)
            {
                if (_canMoveLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.Translate(-2, 0, 0);
                    _hasMoved = true;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.Translate(2, 0, 0);
                    _hasMoved = true;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
            else
            {
                if (_canMoveLeft && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.Translate(-2, 0, 0);
                    _hasMoved = false;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.Translate(2, 0, 0);
                    _hasMoved = false;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
        }
    }
}