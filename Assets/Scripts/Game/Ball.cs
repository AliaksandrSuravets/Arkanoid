using System;
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
        [Header("Sprite")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Header("Trail")]
        [SerializeField] private TrailRenderer _trailRenderer;
        [Header("Explosive")]
        [SerializeField] private float _explosiveRadius = 1f;
        [SerializeField] private LayerMask _blockMask;
        private bool _isExplosive;

        private bool _isGlue;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _offset = transform.position - _platform.transform.position;

            OnCreated?.Invoke(this);
        }

        private void Start()
        {
            Walls.Instance.OnCollisionBall += OnCollisionBall;
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
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                if (_isGlue)
                {
                    _offset = new Vector3(transform.position.x - _platform.transform.position.x, 0.9f, 0);
                    _isStarted = false;
                }
            }

            if (_isExplosive)
            {
                OnDestroyedActions();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _explosiveRadius);
        }

        #endregion

        #region Public methods

        public void ChangeExplosive()
        {
            _isExplosive = true;
            _trailRenderer.startColor = Color.red;
            _spriteRenderer.color = Color.red;
        }

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

        public Ball Clone()
        {
            Ball clone = Instantiate(this, transform.position, Quaternion.identity);
            clone._isStarted = _isStarted;
            clone._offset = _offset;
            clone._rb.velocity = _rb.velocity;
            clone._isGlue = _isGlue;
            clone._isExplosive = _isExplosive;
            return clone;
        }

        public void MakeGooey()
        {
            _isGlue = true;
        }

        public void StartBall()
        {
            _isGlue = false;
            _isStarted = true;
            _rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(0, 10)).normalized * _speed;
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

        private void OnDestroyedActions()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _blockMask);

            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out Bricks bricks))
                {
                    bricks.FullDestroy();
                }
            }
        }

        #endregion
    }
}