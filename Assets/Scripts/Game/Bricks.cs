using System;
using Arkanoid.Game.PickUps;
using Arkanoid.Game.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Bricks : MonoBehaviour
    {
        #region Variables

        [Header("Hp")]
        [SerializeField] private int _hp;
        [SerializeField] private Sprite[] _hpSprites;
        [Header("Score")]
        [SerializeField] private int _score;
        [Header("States")]
        [SerializeField] private bool _isInvisible;
        [Header("Sprite Renderer")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Header("Pick Up")]
        [SerializeField] private PickUp[] _pickUpPrefab;
        private bool _isGameOver;

        #endregion

        #region Events

        public static event Action<Bricks> OnCreated;
        public static event Action<Bricks> OnDestroyed;

        #endregion

        #region Unity lifecycle

        public void Start()
        {
            OnCreated?.Invoke(this);
            HpService.Instance.GameOver += GameOver;
            if (_isInvisible)
            {
                _spriteRenderer.enabled = false;
            }

            if (_hp <= 0)
            {
                Debug.Log("Bricks hp<=0 from start");
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            ApplyHit();
            InvisibilityСheck();
        }

        #endregion

        #region Private methods

        private void ApplyHit()
        {
            if (_isInvisible)
            {
                return;
            }

            _hp--;
            if (_hp <= 0)
            {
                DestroyBrick();
                Destroy(gameObject);
            }
            else
            {
                if (_hp <= 0)
                {
                    return;
                }

                _spriteRenderer.sprite = _hp <= _hpSprites.Length ? _hpSprites[_hp - 1] : _hpSprites[^1];
            }
        }

        private void DestroyBrick()
        {
            HpService.Instance.GameOver -= GameOver;
            if (!_isGameOver)
            {
                GameService.Instance.AddScore(_score);
                if (_pickUpPrefab.Length > 0)
                {
                    PickUpService.Instance.CreatePickUp(transform.position);
                }
            }
        }

        private void GameOver()
        {
            _isGameOver = true;
        }

        private void InvisibilityСheck()
        {
            if (!_isInvisible)
            {
                return;
            }

            _isInvisible = false;
            _spriteRenderer.enabled = true;
        }

        #endregion
    }
}