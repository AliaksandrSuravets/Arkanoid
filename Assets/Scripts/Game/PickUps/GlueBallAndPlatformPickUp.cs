using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class GlueBallAndPlatformPickUp : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            int ballsCount = LevelService.Instance.Balls.Count;
            for (int i = 0; i < ballsCount; i++)
            {
                Ball ball = LevelService.Instance.Balls[i];
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