using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeScaleBallPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _scaleToChange = 0.2f;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            Ball[] balls = GetAllAliveBalls();
            if (balls.Length <= 0)
            {
                return;
            }

            foreach (Ball ball in balls)
            {
                ball.ChangeScale(_scaleToChange);
            }
        }

        #endregion

        #region Private methods

        private Ball[] GetAllAliveBalls()
        {
            return FindObjectsOfType<Ball>();
        }

        #endregion
    }
}