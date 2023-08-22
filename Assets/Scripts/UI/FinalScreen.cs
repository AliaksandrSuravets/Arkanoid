using Arkanoid.Game.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid.UI
{
    public class FinalScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _finalLabel;
        [SerializeField] private TMP_Text _scoreLabel;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _finalLabel.text = HpService.Instance.GameOverBool ? "Game Over" : "You WIN!!!";
            _scoreLabel.text = $"Your score: {GameService.Instance.Score}";
        }

        #endregion
    }
}