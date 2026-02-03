using System.Collections.Generic;
using System.Linq;

public sealed class LeaderboardModel
{
    private readonly List<ScoreEntry> _entries = new();

    public IReadOnlyList<ScoreEntry> Top25 =>
        _entries
            .OrderByDescending(e => e.Score)
            .Take(25)
            .ToList();

    public bool Qualifies(long score)
    {
        if (_entries.Count < 25)
            return true;

        return score > _entries.Min(e => e.Score);
    }

    public void Add(ScoreEntry entry)
    {
        _entries.Add(entry);
        Trim();
    }

    private void Trim()
    {
        _entries.Sort((a, b) => b.Score.CompareTo(a.Score));
        if (_entries.Count > 25)
            _entries.RemoveRange(25, _entries.Count - 25);
    }

    public void Restore(IEnumerable<ScoreEntry> entries)
    {
        _entries.Clear();
        _entries.AddRange(entries);
        Trim();
    }
}
