using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreLabel;
    // Update is called once per frame
    void Update()
    {
        _scoreLabel.text = $"Score: {ScoreSystem.CurrentScore}";
    }
}
