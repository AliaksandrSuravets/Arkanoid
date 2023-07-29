using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    [SerializeField] private Platform _platform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private int _speed;

    private bool _isStarted;
    private Vector3 _offset;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
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

    #endregion

    #region Private methods

    private void MoveWithPad()
    {
        // Vector3 platformPosition = _platform.transform.position;
        // platformPosition += _offset;
        // transform.position = platformPosition;
        // Debug.Log(_platform.transform.position.x);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = new Vector3(Mathf.Clamp(worldMousePosition.x, -13, 13), transform.position.y,
            transform.position.z);
    }

    private void StartBall()
    {
        _isStarted = true;
        _rb.velocity = new Vector2(Random.Range(0, 10), Random.Range(0, 10)).normalized * _speed;
        ;
    }

    #endregion
}