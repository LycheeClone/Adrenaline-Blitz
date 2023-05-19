using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagers
{
    public class LevelRestart : MonoBehaviour
    {
        public bool isFinished;
        private GameObject _gameOverScreen;
        private GameObject _gameOverBackground;
        private GameObject _winScreen;

        private void Awake()
        {
            _gameOverBackground = GameObject.FindGameObjectWithTag("CanvasBackground");
            _gameOverScreen = GameObject.FindGameObjectWithTag("GameOver");
            _winScreen = GameObject.FindGameObjectWithTag("WinScreen");
        }

        private void Start()
        {
            _gameOverBackground.SetActive(false);
            _gameOverScreen.SetActive(false);
            _winScreen.SetActive(false);
        }

        private void Update()
        {
            GameRestart();
        }

        private void GameRestart()
        {
            if (isFinished && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                isFinished = true;
                _gameOverBackground.SetActive(true);
                _gameOverScreen.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("EndPoint"))
            {
                isFinished = true;
                _gameOverBackground.SetActive(true);
                _winScreen.SetActive(true);
            }
        }
    }
}