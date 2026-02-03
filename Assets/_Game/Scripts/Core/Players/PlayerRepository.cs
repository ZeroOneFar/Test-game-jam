using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerRepository
{
    private const string Key = "players";
    private readonly List<PlayerProfile> _players = new();

    public PlayerRepository()
    {
        Load();
    }

    public IReadOnlyList<PlayerProfile> All => _players;

    public PlayerProfile Add(string name)
    {
        var player = new PlayerProfile(name);
        _players.Add(player);
        Save();
        return player;
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey(Key))
            return;

        var raw = PlayerPrefs.GetString(Key);
        foreach (var n in raw.Split('|'))
            _players.Add(new PlayerProfile(n));
    }

    private void Save()
    {
        var joined = string.Join("|", _players.ConvertAll(p => p.Name));
        PlayerPrefs.SetString(Key, joined);
        PlayerPrefs.Save();
    }
}
