using System;
using UnityEngine;

namespace CameraControls
{
    public class CameraControls : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;

        [SerializeField] private Transform target;


        private void Awake()
        {
            CalculateOffset();
        }

        private void FixedUpdate()
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }

        private void CalculateOffset()
        {
            offset = transform.position - target.position;
        }
    }
}