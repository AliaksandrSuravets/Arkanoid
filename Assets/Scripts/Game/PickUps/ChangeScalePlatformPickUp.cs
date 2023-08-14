using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeScalePlatformPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _scaleToChange = 0.1f;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            Platform[] Platforms = GetAllAlivePlatforms();
            if (Platforms.Length <= 0)
            {
                return;
            }

            foreach (Platform Platform in Platforms)
            {
                Platform.ChangeScale(_scaleToChange);
            }
        }

        #endregion

        #region Private methods

        private Platform[] GetAllAlivePlatforms()
        {
            return FindObjectsOfType<Platform>();
        }

        #endregion

        //private Ball _ball;
    }
}