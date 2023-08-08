using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Platform _platform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _speed;
    [SerializeField] private bool _isStarted;
    private Vector3 _offset;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Walls.Instance.OnCollisionBall += OnCollisionBall;
        _offset = transform.position - _platform.transform.position;
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
        _isStarted = true;
        _rb.velocity = new Vector2(Random.Range(-10, 10), Random.Range(0, 10)).normalized * _speed;
    }

    #endregion
}