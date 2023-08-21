using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class PlusHpPickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _hpToChange = 1;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            HpService.Instance.AddHP(_hpToChange);
        }

        #endregion
    }
}