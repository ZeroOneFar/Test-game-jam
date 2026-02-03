public readonly struct MatchScored
{
    public readonly int Points;
    public MatchScored(int points) => Points = points;
}

public readonly struct FinalScoreComputed
{
    public readonly long Score;
    public FinalScoreComputed(long score) => Score = score;
}
