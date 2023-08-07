using System;
using UnityEngine;
 
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Bricks[] blocks = GetAllAliveBlocks();
            if (blocks.Length == 0)
            {
                Debug.Log("OnAllBlocksDestroyed");
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        #endregion

        #region Private methods

        private Bricks[] GetAllAliveBlocks()
        {
            return FindObjectsOfType<Bricks>();
        }

        #endregion
    }
 