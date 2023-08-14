using System;
using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Walls : SingletonMonoBehaviour<Walls>
    {
        #region Events

        public event Action OnCollisionBall;

        #endregion

        #region Unity lifecycle

        private void OnTriggerExit2D(Collider2D other)
        {
            Ball[] balls = GetAllAliveBalls();

            if (other.gameObject.CompareTag(Tags.Ball))
            {
                if (balls.Length > 1)
                {
                    Destroy(other.gameObject);
                    return;
                }

                OnCollisionBall?.Invoke();
            }
            else
            {
                Destroy(other.gameObject);
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