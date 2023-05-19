using UnityEngine;
using DG.Tweening;
using SceneManagers;
using ScoreControls;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;

        private ScoreManager _scoreManager;

        //Side Direction Move Controller Variable
        private bool _hasMoved;

        //The variable that holds the right to move Left
        private bool _canMoveLeft = true;

        //the variable that holds the right to move right
        private bool _canMoveRight = true;

        // Player's Starting Speed
        private float _speed = 40f;

        // Value For Speed Increase
        private float _speedIncrease = 1.5f;

        // How Many Speed Increases Will be Made Every "timer" Variable
        private float _timer = 0.5f;

        // Keeps the Elapsed Time
        private float _timeCounter;

        //Player Rigidbody Constraints
        public bool rbFreezeVariables;

        private void Start()
        {
            _scoreManager = FindObjectOfType<ScoreManager>();
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
            if (!rbFreezeVariables)
            {
                _timeCounter += Time.deltaTime;
                if (_timeCounter > _timer)
                {
                    _speed += _speedIncrease;
                    _timeCounter = 0.0f;
                }
            }
        }

        private void GravityControl()
        {
            //Controls the Behavior of Falling At Specific Locations
            if (transform.position.z >= 500)
            {
                _rb.AddForce(Vector3.down * 85, ForceMode.Acceleration);
            }

            //Controls for Return to the Default Gravity
            if (transform.position.z >= 640)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
            }
        }

        //Constant Movement In The Z Axis
        private void ConstMovement()
        {
            if (!rbFreezeVariables)
            {
                Vector3 direction = Vector3.forward;
                _rb.AddForce(direction.normalized * _speed, ForceMode.Acceleration); // Speed up the object   
            }

            // Limit the maximum speed
            if (_rb.velocity.magnitude > _speed)
            {
                _rb.velocity = _rb.velocity.normalized * _speed;
            }
        }


        //Function That Determines the Character's Right to Move Left and Right
        private void SideMovement()
        {
            //Checks freeze variables in rigidbody component
            rbFreezeVariables = _rb.freezeRotation;

            if (!_hasMoved)
            {
                if (_canMoveLeft && rbFreezeVariables == false &&
                    (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.DOMoveX(-2, 0.25f);
                    _scoreManager.score++;
                    _hasMoved = true;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && rbFreezeVariables == false &&
                         (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.DOMoveX(2, 0.25f);
                    _scoreManager.score++;
                    _hasMoved = true;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
            else
            {
                if (_canMoveLeft && rbFreezeVariables == false &&
                    (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    transform.DOMoveX(-2, 0.25f);
                    _scoreManager.score++;
                    _hasMoved = false;
                    _canMoveLeft = false;
                    _canMoveRight = true;
                }
                else if (_canMoveRight && rbFreezeVariables == false &&
                         (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    transform.DOMoveX(2, 0.25f);
                    _scoreManager.score++;
                    _hasMoved = false;
                    _canMoveLeft = true;
                    _canMoveRight = false;
                }
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                DOTween.Kill(transform);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EndPoint"))
            {
                DOTween.Kill(transform);
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                FindObjectOfType<LevelRestart>().isFinished = true;
            }
        }
    }
}