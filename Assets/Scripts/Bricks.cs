using UnityEngine;

public class Bricks : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _hp;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _hpSprites;
    [SerializeField] private int _valueScore;

    #endregion

    #region Unity lifecycle

    public void OnCollisionEnter2D(Collision2D other)
    {
        _hp--;
        if (_hp == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _spriteRenderer.sprite = _hpSprites[_hp - 1];
        }
       
    }

    #endregion
}