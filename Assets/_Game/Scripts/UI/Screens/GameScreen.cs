using UnityEngine;
using TMPro;

public sealed class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text chances;

    private int _mistakes;

    private void OnEnable()
    {
        EventBus.Subscribe<PlayerSelected>(e =>
            playerName.text = e.Player.Name);

        EventBus.Subscribe<MatchScored>(e =>
            score.text = $"Score: {e.Points}");

        EventBus.Subscribe<CardsMismatched>(_ =>
        {
            _mistakes++;
            chances.text = $"Mistakes: {_mistakes} / 3";
        });
    }

    private void OnDisable()
    {
        _mistakes = 0;
        score.text = "Score: 0";
        chances.text = "Mistakes: 0 / 3";
    }
}

