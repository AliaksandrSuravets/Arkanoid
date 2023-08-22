using Arkanoid.Game.Services;
using Arkanoid.Utility;
using UnityEngine.SceneManagement;

namespace Arkanoid.Infrastructure
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public methods

        public void LoadNextGameScene()
        {
            if (HpService.Instance.GameOverBool || SceneManager.GetActiveScene().name == SceneLoaderHelper.End ||
                SceneManager.GetActiveScene().name == SceneLoaderHelper.StartGame)
            {
                return;
            }

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        #endregion
    }
}