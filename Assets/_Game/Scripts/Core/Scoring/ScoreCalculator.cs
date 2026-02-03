using System;

public sealed class ScoreCalculator
{
    private readonly ScoreModel _model = new();
    private readonly DifficultyController _difficulty;

    public ScoreCalculator(DifficultyController difficulty)
    {
        _difficulty = difficulty;

        EventBus.Subscribe<CardsMatched>(_ => OnMatch());
        EventBus.Subscribe<GameOverTriggered>(_ => OnGameOver());
    }

    private void OnMatch()
    {
        // Fixed base points per match (tunable later)
        _model.Add(100);
    }

    private void OnGameOver()
    {
        var baseScore = _model.CurrentGameScore;
        var previewTime = _difficulty.GetPreviewTime();

        double multiplier =
            1.0 + (3.0 - previewTime) * 0.001;

        double final =
            baseScore * multiplier;

        long rounded = (long)Math.Round(final);

        EventBus.Raise(new FinalScoreComputed(rounded));
        _model.Reset();
    }
}
