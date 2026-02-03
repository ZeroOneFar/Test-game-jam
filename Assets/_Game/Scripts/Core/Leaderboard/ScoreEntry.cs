public sealed class ScoreEntry
{
    public string PlayerName { get; }
    public long Score { get; }

    public ScoreEntry(string playerName, long score)
    {
        PlayerName = playerName;
        Score = score;
    }
}
