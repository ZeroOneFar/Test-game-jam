using UnityEngine;
using TMPro;
using System;

public sealed class GameScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text chances;

    private int _mistakes;

    private void Start()
    {
        EventBus.Subscribe<PlayerSelected>(e =>
            playerName.text = e.Player.Name);

        EventBus.Subscribe<MatchScored>(e =>
            score.text = $" {e.Points}");

        EventBus.Subscribe<CardsMismatched>(CalculateMistake);
    }

    private void CalculateMistake(CardsMismatched mismatched)
    {
        Debug.Log("update ui for card mismatched");
        _mistakes++;
        chances.text = $"{_mistakes} / 3";
    }

    private void OnDisable()
    {
        _mistakes = 0;
        score.text = "Score: 0";
        chances.text = "Mistakes: 0 / 3";
    }
}

