using Arkanoid.Game.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid.UI
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private TMP_Text _hpLabel;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            UpdateScore();
            UpdateHp();
        }

        #endregion

        #region Private methods

        private void UpdateHp()
        {
            _hpLabel.text = $"HP: {HpService.Instance.Hp}";
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }

        #endregion
    }
}