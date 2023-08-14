using System;
using Arkanoid.Game.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private int _speed;
        [SerializeField] private bool _isStarted;
        [SerializeField] private Vector3 _offset;
        private bool _isGlue;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            Walls.Instance.OnCollisionBall += OnCollisionBall;
            //_offset = transform.position - _platform.transform.position;
            _offset = new Vector3(0, 0.625f, 0);
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            MoveWithPad();

            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }

        private void OnDestroy()
        {
            Walls.Instance.OnCollisionBall -= OnCollisionBall;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                if (_isGlue)
                {
                    _isStarted = false;
                }
            }
        }

        #endregion

        #region Public methods

        public void ChangeScale(float valueChange)
        {
            Vector3 localScale = transform.localScale;
            localScale = new Vector3(localScale.x + valueChange, localScale.y + valueChange, localScale.z);
            transform.localScale = localScale;
        }

        public void ChangeSpeed(float valueChange)
        {
            Vector2 velocity = _rb.velocity;
            velocity = new Vector2(velocity.x + valueChange, velocity.y + valueChange);
            _rb.velocity = velocity;
        }

        public void CreateNewBall()
        {
            Instantiate(this, transform.position, Quaternion.identity).StartBall();
        }

        public void MakeGooey()
        {
            // _offset = new Vector3( (transform.position.x - _platform.transform.position.x) , 0.5f, 0);
            _isGlue = true;
        }

        #endregion

        #region Private methods

        private void MoveWithPad()
        {
            Vector3 platformPosition = _platform.transform.position;
            platformPosition += _offset;
            transform.position = platformPosition;
        }

        private void OnCollisionBall()
        {
            _isStarted = false;
        }

        private void StartBall()
        {
            _isGlue = false;
            _isStarted = true;
            _rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(0, 10)).normalized * _speed;
        }

        #endregion
    }
}