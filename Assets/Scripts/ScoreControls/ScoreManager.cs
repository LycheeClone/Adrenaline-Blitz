using PlayerControls;
using UnityEngine;
using TMPro;

namespace ScoreControls
{
    public class ScoreManager : MonoBehaviour
    {
        public int score;
        public int startPosition = -239;
        private TextMeshProUGUI _scoreText;
        private GameObject _playerTransform;
        private PlayerController _playerController;

        private void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
            _scoreText = GetComponent<TextMeshProUGUI>();
            _playerTransform = GameObject.FindWithTag("Player");
        }

        private void Update()
        {
            ScoreIncreasePerDıstance();
            _scoreText.text = "Score: " + score;
        }
        
        private void ScoreIncreasePerDıstance()
        {
            var playerTransform2 = _playerTransform.transform.position.z;

            if (playerTransform2 - startPosition > 100)
            {
                score++;
                startPosition += 100;
            }
        }
    }
}