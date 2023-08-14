using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeScorePickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _scoreToChange = 10;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            Services.GameService.Instance.AddScore(_scoreToChange);
        }

        #endregion
    }
}