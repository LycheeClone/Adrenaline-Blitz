using System;
using UnityEngine;

namespace PlayerControls
{
    public class PlayerController : MonoBehaviour
    {
        //Default Movement Speed
        private float _movementSpeed = 400;

        //Side Direction Move Controller Variable
        private bool _hasMoved = false;

        //Player's Rigidbody
        private Rigidbody _rb;

        //The variable that holds the right to move Left
        private bool _canMoveLeft = true;

        //the variable that holds the right to move right
        private bool _canMoveRight = true;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            SideMovement();
        }

        private void FixedUpdate()
        {
            ConstMovement();
        }

        private void ConstMovement()
        {
            _rb.AddForce(Vector3.forward * (_movementSpeed * Time.fixedDeltaTime));
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