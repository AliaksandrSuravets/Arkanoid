using Arkanoid.Utility;
using UnityEngine;

namespace Arkanoid.Game.Services
{
    public class AudioService : SingletonMonoBehaviour<AudioService>
    {
        #region Variables

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Public methods

        public void PlayAudio(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }

        #endregion
    }
}