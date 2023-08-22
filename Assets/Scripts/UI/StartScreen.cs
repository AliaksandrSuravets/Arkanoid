using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        public Button[] LevelButtons;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            for (int i = 0; i < LevelButtons.Length; i++)
            {
                int indexScene = i + 1;
                LevelButtons[i].onClick.AddListener(() => LoadLevelScene(indexScene));
            }
        }

        #endregion

        #region Private methods

        private void LoadLevelScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        #endregion
    }
}