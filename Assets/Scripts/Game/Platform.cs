using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            MoveWithMouse();
        }

        #endregion

        #region Public methods

        public void ChangeScale(float valueChange)
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x + valueChange, localScale.y, localScale.z);
            transform.localScale = localScale;
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 currentPosition = transform.position;
            currentPosition.x = worldMousePosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}