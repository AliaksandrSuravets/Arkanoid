using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeSpeedPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _speedToChange = 1f;

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
                ball.ChangeSpeed(_speedToChange);
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