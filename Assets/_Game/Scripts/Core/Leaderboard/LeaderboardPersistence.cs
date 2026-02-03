using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardPersistence
{
    private const string Key = "leaderboard";

    public static void Save(IEnumerable<ScoreEntry> entries)
    {
        var raw = "";
        foreach (var e in entries)
            raw += $"{e.PlayerName},{e.Score};";

        PlayerPrefs.SetString(Key, raw);
        PlayerPrefs.Save();
    }

    public static List<ScoreEntry> Load()
    {
        var list = new List<ScoreEntry>();

        if (!PlayerPrefs.HasKey(Key))
            return list;

        var raw = PlayerPrefs.GetString(Key);
        var rows = raw.Split(';');

        foreach (var r in rows)
        {
            if (string.IsNullOrWhiteSpace(r))
                continue;

            var parts = r.Split(',');
            list.Add(new ScoreEntry(parts[0], long.Parse(parts[1])));
        }

        return list;
    }
}
