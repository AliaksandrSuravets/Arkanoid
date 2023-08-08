using UnityEngine;

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
    private bool _isGameOver;

    #endregion

    #region Unity lifecycle

    public void Start()
    {
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

    public void OnDestroy()
    {
        HpService.Instance.GameOver -= GameOver;
        if (!_isGameOver)
        {
            GameService.Instance.AddScore(_score);
        }
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
        if (_hp == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _spriteRenderer.sprite = _hp <= _hpSprites.Length ? _hpSprites[_hp - 1] : _hpSprites[^1];
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