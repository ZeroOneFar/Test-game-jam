using UnityEngine;
using System.Collections.Generic;

public sealed class UIStateBinder : MonoBehaviour
{
    [SerializeField] private HomeScreen home;
    [SerializeField] private PlayerSelectScreen playerSelect;
    [SerializeField] private PreviewScreen preview;
    [SerializeField] private GameScreen game;
    [SerializeField] private GameOverScreen gameOver;

    private Dictionary<GameState, MonoBehaviour> _map;

    private void Awake()
    {
        _map = new()
        {
            { GameState.Home, home },
            { GameState.PlayerSelect, playerSelect },
            { GameState.Preview, preview },
            { GameState.Playing, game },
            { GameState.GameOver, gameOver }
        };

        EventBus.Subscribe<GameStateChanged>(OnStateChanged);
    }

    private void OnStateChanged(GameStateChanged evt)
    {
        foreach (var s in _map.Values)
            s.gameObject.SetActive(false);

        if (_map.TryGetValue(evt.State, out var screen))
            screen.gameObject.SetActive(true);
    }
}
