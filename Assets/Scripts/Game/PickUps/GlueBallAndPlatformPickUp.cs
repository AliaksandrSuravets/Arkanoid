using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class GlueBallAndPlatformPickUp : PickUp
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
                ball.MakeGooey();
            }
        }

        #endregion

        #region Private methods

        private Ball[] GetAllAliveBalls()
        {
            return FindObjectsOfType<Ball>();
        }

        #endregion

        //private Ball _ball;
    }
}