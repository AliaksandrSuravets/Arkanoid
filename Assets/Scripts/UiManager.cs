using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TMP_Text _scoreLabel;

    #endregion

    #region Unity lifecycle

    private void Update()
    {
        _scoreLabel.text = $"Score: {ScoreSystem.CurrentScore}";
    }

    #endregion
}