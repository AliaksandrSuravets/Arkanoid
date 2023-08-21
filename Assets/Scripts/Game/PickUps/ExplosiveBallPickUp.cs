using Arkanoid.Game.Services;

namespace Arkanoid.Game.PickUps
{
    public class ExplosiveBallPickUp : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            int ballsCount = LevelService.Instance.Balls.Count;
            for (int i = 0; i < ballsCount; i++)
            {
                Ball ball = LevelService.Instance.Balls[i];
                ball.ChangeExplosive();
            }
        }

        #endregion
    }
}