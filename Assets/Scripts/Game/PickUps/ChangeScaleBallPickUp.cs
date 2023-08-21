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
            int ballsCount = LevelService.Instance.Balls.Count;
            for (int i = 0; i < ballsCount; i++)
            {
                Ball ball = LevelService.Instance.Balls[i];
                ball.ChangeScale(_scaleToChange);
            }
        }

        #endregion
    }
}