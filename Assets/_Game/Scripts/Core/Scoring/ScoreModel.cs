public sealed class ScoreModel
{
    public int CurrentGameScore { get; private set; }

    public void Add(int points)
    {
        CurrentGameScore += points;
    }

    public void Reset()
    {
        CurrentGameScore = 0;
    }
}
