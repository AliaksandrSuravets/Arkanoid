using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Variables

        [SerializeField] private GameObject _pauseScreen;

        #endregion

        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Private methods

        private void TogglePause()
        {
            IsPaused = !IsPaused;
            _pauseScreen.SetActive(IsPaused);
            Time.timeScale = IsPaused ? 0 : 1;
        }

        #endregion
    }
}