using Arkanoid.Game.PickUps;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class PickUpService : SingletonMonoBehaviour<PickUpService>
    {
        #region Variables

        [Header("Pick Up")]
        [Range(0, 100)]
        [SerializeField] private int _pickUpDropChance = 50;

        #endregion

        #region Public methods

        public void CreatePickUp(PickUp[] pickUps, Vector3 position)
        {
            int chance = Random.Range(0, 101);
            if (_pickUpDropChance >= chance)
            {
                Instantiate(pickUps[Random.Range(0, pickUps.Length)], position, Quaternion.identity);
            }
        }

        #endregion
    }
}