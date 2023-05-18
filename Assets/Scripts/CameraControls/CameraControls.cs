using UnityEngine;

namespace CameraControls
{
    public class CameraControls : MonoBehaviour
    {
        private Vector3 _offset;
        private Transform _target;

        private void Awake()
        {
            _target = GameObject.FindWithTag("Player").transform;
            CalculateOffset();
        }

        private void LateUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            transform.position = _target.position + _offset;
            transform.LookAt(_target);
        }

        private void CalculateOffset()
        {
            _offset = transform.position - _target.position;
        }
    }
}