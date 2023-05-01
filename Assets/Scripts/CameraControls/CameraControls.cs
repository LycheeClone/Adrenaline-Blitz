using System;
using PlayerControls;
using UnityEngine;

namespace CameraControls
{
    public class CameraControls : MonoBehaviour
    {
        //The variable that holds the distance between the player and the camera.
        private Vector3 Offset;

        //Player's target.
        private Transform _target;


        private void Awake()
        {
            _target = GameObject.FindWithTag("Player").transform;
            //_target = FindObjectOfType<PlayerController>().PlayerTransform;
            //_target = GetComponent<PlayerController>().PlayerTransform.transform;
            CalculateOffset();
        }

        private void LateUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            transform.position = _target.position + Offset;
            transform.LookAt(_target);
        }

        //Function That Calculates Distance
        private void CalculateOffset()
        {
            Offset = transform.position - _target.position;
        }
    }
}