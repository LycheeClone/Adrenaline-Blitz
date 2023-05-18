using System;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

namespace ScoreControls
{
    public class ScoreManager : MonoBehaviour
    {
        public int score;
        public int startPosition = -245;
        public TextMeshProUGUI textMessage;
        private GameObject _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            var playerTransform2 = _playerTransform.transform.position.z;

            if (playerTransform2 - startPosition > 100)
            {
                score++;
                startPosition += 100;
                textMessage.text = "Score: " + score;
            }
        }
    }
}