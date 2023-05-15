using UnityEngine;
using DG.Tweening;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        //Side Direction Move Controller Variable
        private bool _hasMoved = false;

        //Player's Rigidbody
        private Rigidbody _rb;

        //The variable that holds the right to move Left
        private bool _canMoveLeft = true;

        //the variable that holds the right to move right
        private bool _canMoveRight = true;

        // Player's Starting Speed
        private float _speed = 20f;

        // Increase Amount for Increase
        private float _speedIncrease = 1f;

        // How Many Speed Increases Will be Made Every "timer"
        private float _timer = 0.5f;

        // Keeps the Elapsed Time
        private float _timeCounter = 0.0f;
        private bool _rbFreezevariables;

        private void Start()
        {
            SideMovement();
            _rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            SideMovement();
        }

        void FixedUpdate()
        {
            SpeedBooster();

            ConstMovement();

            GravityControl();
        }

        //Player's Movement Increase Per _timer variable
        private void SpeedBooster()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter > _timer)
            {
                _speed += _speedIncrease;
                _timeCounter = 0.0f;
            }
        }

        private void GravityControl()
        {
            //Controls the Behavior of Falling At Specific Locations
            if (transform.position.z >= 500)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.down * 70, ForceMode.Acceleration);
            }

            //Controls for Return to the Default Gravity
            if (transform.position.z >= 640)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
            }
        }

        private void ConstMovement()
        {
            Vector3 direction = Vector3.forward;
            _rb.AddForce(direction.normalized * _speed, ForceMode.Acceleration); // Speed up the object

            // Limit the maximum speed
            if (_rb.velocity.magnitude > _speed)
            {
                _rb.velocity = _rb.velocity.normalized * _speed;
            }
        }


        //Function That Determines the Character's Right to Move Left and Right
        private void SideMovement()
        {
            //Checking freeze variables in rigidbody component
            _rbFreezevariables = GetComponent<Rigidbody>().freezeRotation;

            if (!_hasMoved)
            {
                if (_canMoveLeft && _rbFreezevariables == false &&
                    (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.DOMoveX(-2, 0.25f);
                    _hasMoved = true;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && _rbFreezevariables == false &&
                         (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.DOMoveX(2, 0.25f);
                    _hasMoved = true;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
            else
            {
                if (_canMoveLeft && _rbFreezevariables == false &&
                    (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.DOMoveX(-2, 0.25f);
                    _hasMoved = false;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && _rbFreezevariables == false &&
                         (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.DOMoveX(2, 0.25f);
                    _hasMoved = false;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
        }

        // Checking For Object Collisions
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                DOTween.Kill(transform);
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}