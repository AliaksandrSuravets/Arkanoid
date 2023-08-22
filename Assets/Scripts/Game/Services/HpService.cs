using System;
using Arkanoid.Infrastructure;
using Arkanoid.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid.Game.Services
{
    public class HpService : SingletonMonoBehaviour<HpService>
    {
        #region Variables

        [SerializeField] private int _hp;
        [SerializeField] private TMP_Text _gameOverScoreLabel;
        [SerializeField] private GameObject _gameOver;

        #endregion

        #region Events

        public event Action GameOver;

        #endregion

        #region Properties

        public bool GameOverBool { get; private set; }

        public int Hp { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Hp = _hp;
            Walls.Instance.OnCollisionBall += OnCollisionBall;
        }

        private void Update()
        {
            HpCheck();
        }

        private void OnDestroy()
        {
            Walls.Instance.OnCollisionBall -= OnCollisionBall;
        }

        #endregion

        #region Public methods

        public void AddHP(int value)
        {
            Hp += value;
        }

        #endregion

        #region Private methods

        private void HpCheck()
        {
            if (Hp > 0)
            {
                return;
            }

            //Time.timeScale = 0;
            //_gameOver.SetActive(true);
            //_gameOverScoreLabel.text = $"Score: {GameService.Instance.Score}";
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //   Time.timeScale = 1;
            //    _gameOver.SetActive(false);
            GameOverBool = true;
            GameOver?.Invoke();
            //Hp = _hp;
            SceneManager.LoadScene(SceneLoaderHelper.End);
            //}
        }

        private void MinusHP()
        {
            Hp -= 1;
        }

        private void OnCollisionBall()
        {
            MinusHP();
        }

        #endregion
    }
}