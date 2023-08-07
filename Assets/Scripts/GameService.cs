
 
    using UnityEngine;

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

        private void GameOver()
        {
            Score = 0;
            Debug.Log("GameService GameOver");
        }
   
        
        public void AddScore(int value)
        {
            Score += value;
        }

        #endregion

        #region Private methods

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
 