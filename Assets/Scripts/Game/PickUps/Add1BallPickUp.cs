using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class Add1BallPickUp : PickUp
    {
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
                ball.CreateNewBall();
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