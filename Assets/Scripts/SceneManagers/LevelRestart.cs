using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagers
{
    public class LevelRestart : MonoBehaviour
    {

        public bool isFinished;
        private GameObject _gameOver;
        private GameObject _endImage;

        private void Awake()
        {
            _endImage = GameObject.FindGameObjectWithTag("GameOverImage");
            _gameOver = GameObject.FindGameObjectWithTag("GameOver");
        }

        private void Start()
        {
            _endImage.SetActive(false);
            _gameOver.SetActive(false);
        }

        private void Update()
        {
            GameOverFuncs();
            GameRestart();
        }

        private void GameRestart()
        {
            if (isFinished == true && Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void GameOverFuncs()
        {
            if (isFinished == true)
            {
                _endImage.SetActive(true);
                _gameOver.SetActive(true);

            }
        }
        

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                isFinished = true;    
            }
        }
    }
}
