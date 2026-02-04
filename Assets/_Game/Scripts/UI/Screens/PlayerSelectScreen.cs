using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed class PlayerSelectScreen : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Dropdown playerDropdown;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject emptyStatePanel;
    [SerializeField] private GameObject addPlayerPanel;

    private PlayerRepository _repo;
    private List<PlayerProfile> _players = new();
    private PlayerProfile _selectedPlayer;

    public void Init(PlayerRepository repo)
    {
        _repo = repo;

        EventBus.Subscribe<PlayerAddConfirmed>(OnPlayerAdded);

        Refresh();
        playButton.onClick.AddListener(OnPlayClicked);
        playerDropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void Refresh()
    {
        _players = new List<PlayerProfile>(_repo.All);

        emptyStatePanel.SetActive(_players.Count == 0);
        playerDropdown.gameObject.SetActive(_players.Count > 0);
        playButton.interactable = _players.Count > 0;

        if (_players.Count == 0)
            return;

        playerDropdown.ClearOptions();

        var options = new List<string>();
        foreach (var p in _players)
            options.Add(p.Name);

        playerDropdown.AddOptions(options);

        // Default selection
        playerDropdown.value = 0;
        SelectPlayer(0);
    }

    private void OnDropdownChanged(int index)
    {
        SelectPlayer(index);
    }

    private void SelectPlayer(int index)
    {
        if (index < 0 || index >= _players.Count)
            return;

        _selectedPlayer = _players[index];
        EventBus.Raise(new PlayerSelected(_selectedPlayer));
    }

    private void OnPlayClicked()
    {
        if (_selectedPlayer == null)
            return;

        EventBus.Raise(new PlayerConfirmed());
    }

    private void OnPlayerAdded(PlayerAddConfirmed e)
    {
        _repo.Add(e.Name);
        Refresh();
    }

    public void ShowAddPlayerPanel()
    {
        emptyStatePanel.SetActive(false);
        addPlayerPanel.SetActive(true);
    }
}

public readonly struct PlayerAddRequested { }

public readonly struct PlayerConfirmed{}
public readonly struct PlayerAddConfirmed
{
    public readonly string Name;
    public PlayerAddConfirmed(string name) => Name = name;
}