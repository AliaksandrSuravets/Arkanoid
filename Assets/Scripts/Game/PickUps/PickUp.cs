using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Unity lifecycle
        [Header("Pick up option")]
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private int _baseScoreToChange;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        private void PlayAudio()
        {
            AudioService.Instance.PlayAudio(_audioClip);
        }
        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            PlayAudio();
            GameService.Instance.AddScore(_baseScoreToChange);
        }

        #endregion
    }
}