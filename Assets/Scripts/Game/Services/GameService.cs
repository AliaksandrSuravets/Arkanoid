using Arkanoid.Infrastructure;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Properties

        public int Score { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
            HpService.Instance.GameOver += GameOver;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnAllBlocksDestroyed;
            HpService.Instance.GameOver -= GameOver;
        }

        #endregion

        #region Public methods

        public void AddScore(int value)
        {
            Score = Mathf.Max(0, Score + value);
        }

        #endregion

        #region Private methods

        private void GameOver()
        {
            //Score = 0;
            Debug.Log("GameService GameOver");
        }

        private void LoadNextLevel()
        {
            SceneLoader.Instance.LoadNextGameScene();
        }

        private void OnAllBlocksDestroyed()
        {
            LoadNextLevel();
        }

        #endregion
    }
}